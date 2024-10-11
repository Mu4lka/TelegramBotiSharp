using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;
using TelegramBotiSharp.Storages;

namespace TelegramBotExtension.Handling;

public abstract class MessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Message;

    public abstract Task HandleAsync(TelegramContext context);

    public TelegramContext GetContext(ITelegramBotClient botClient, IStorage<long> storage, Update update)
        => new(
            botClient,
            storage,
            update,
            update.Message!.From!,
            update.Message.Text!
            );
}
