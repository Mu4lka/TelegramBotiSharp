using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.EditedMessage"/> handler
/// </summary>
public abstract class EditedMessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.EditedMessage;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.EditedMessage!.From,
            builder.Update.EditedMessage.Text,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
