using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TelegramBotiSharp.Filters;
using TelegramBotiSharp.Handling.ErrorHandling;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Polling;

/// <summary>
/// Provides an implementation of <see cref="IUpdateHandler"/> that handles specific update types
/// </summary>
public class UpdateHandler : IUpdateHandler
{
    private IEnumerable<IUpdateTypeHandler> _handlers;
    private IErrorHandler? _errorHandler;
    private IUsersStorage<long> _storage;

    public UpdateHandler(
        IEnumerable<IUpdateTypeHandler> handlers,
        IUsersStorage<long> storage = default!,
        IErrorHandler? errorHandler = null!)
    {
        _storage = storage ??= new MemoryUsersStorage<long>();
        _handlers = handlers;
        _storage = storage;
        _errorHandler = errorHandler;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handlers = _handlers.Where(h => h.UpdateType == update.Type);

        if (!handlers.Any()) return;

        var context = handlers
            .First()
            .GetContext(TelegramContextBuilder.Create(botClient, update, _storage, cancellationToken));

        foreach (var handler in handlers)
        {
            var filters = handler
                .GetType()
                .GetMethod(nameof(handler.HandleAsync))!
                .GetCustomAttributes(false)
                .OfType<FilterAttribute>();

            var passedFilters = filters.All(filter => filter.CallAsync(context).Result);

            if (passedFilters)
            {
                await handler.HandleAsync(context);
                return;
            }
        }
    }

    public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, HandleErrorSource source, CancellationToken cancellationToken)
    {
        if (_errorHandler is null)
            throw exception;

        await _errorHandler.HandleErrorAsync(botClient, exception, source, cancellationToken);
    }
}
