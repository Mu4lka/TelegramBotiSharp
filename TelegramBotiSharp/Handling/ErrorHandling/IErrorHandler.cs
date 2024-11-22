using Telegram.Bot;
using Telegram.Bot.Polling;

namespace TelegramBotiSharp.Handling.ErrorHandling;

/// <summary>
/// Error handler
/// </summary>
public interface IErrorHandler
{
    Task HandleErrorAsync(ITelegramBotClient client, Exception exception, HandleErrorSource source, CancellationToken token);
}