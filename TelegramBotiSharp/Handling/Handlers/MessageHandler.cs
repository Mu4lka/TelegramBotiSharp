using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Handling;

public abstract class MessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Message;

    public abstract Task HandleUpdateAsync(TelegramContext context);

    public TelegramContext GetContext(ITelegramBotClient botClient, IStorage storage, Update update)
        => new(
            botClient,
            storage,
            update,
            update.Message!.From!.Id,
            update.Message.Text!
            );
}
