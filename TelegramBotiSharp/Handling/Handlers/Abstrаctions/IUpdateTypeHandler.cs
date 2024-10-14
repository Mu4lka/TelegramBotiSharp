using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers.Abstrаctions;

/// <summary>
/// Update type handler
/// </summary>
public interface IUpdateTypeHandler
{
    /// <summary>
    /// Update type
    /// </summary>
    UpdateType UpdateType { get; }

    /// <summary>
    /// Handling method
    /// </summary>
    /// <param name="context">Сontext</param>
    Task HandleAsync(TelegramContext context);

    /// <summary>
    /// Method returning context
    /// </summary>
    /// <param name="builder">Сontext builder</param>
    TelegramContext GetContext(TelegramContextBuilder builder);
}