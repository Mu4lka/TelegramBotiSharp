using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling;

public abstract class MessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Message;

    public abstract Task HandleUpdateAsync(TelegramContext context);

    public TelegramContext GetContext(ITelegramBotClient botClient, Update update)
        => new(botClient, update, update.Message!.From!.Id, update.Message.Text!);
}
