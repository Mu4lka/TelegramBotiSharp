using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.Message"/> handler
/// </summary>
public abstract class MessageHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.Message;

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.Message!.From!,
            builder.Update.Message.Text!,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
