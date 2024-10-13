using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using TelegramBotiSharp.Filters;
using TelegramBotiSharp.Handling.Handlers;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Handling.Polling;

public class UpdateHandler : IUpdateHandler
{
    private IEnumerable<IUpdateTypeHandler> _handlers;
    private Func<ITelegramBotClient, Exception, CancellationToken, Task> _pollingErrorHandler;
    private IStorage<long> _storage;

    public UpdateHandler(
        IEnumerable<IUpdateTypeHandler> handlers,
        IStorage<long> storage,
        Func<ITelegramBotClient, Exception, CancellationToken, Task> pollingErrorHandler = default!)
    {
        _handlers = handlers;
        _storage = storage;
        _pollingErrorHandler = pollingErrorHandler;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        var handlers = _handlers.Where(h => h.UpdateType == update.Type);

        if (!handlers.Any()) return;

        var context = handlers.First().GetContext(botClient, _storage, update);

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

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        if (_pollingErrorHandler is null)
            throw exception;

        await _pollingErrorHandler.Invoke(botClient, exception, cancellationToken);
    }
}
