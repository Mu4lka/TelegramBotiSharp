using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

public abstract class CallbackQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.CallbackQuery;

    public abstract Task HandleAsync(TelegramContext context);

    public TelegramContext GetContext(ITelegramBotClient botClient, IStorage<long> storage, Update update)
        => new(
            botClient,
            storage,
            update,
            update.CallbackQuery!.From,
            update.CallbackQuery.Data!
            );
}
