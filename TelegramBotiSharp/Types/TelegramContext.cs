using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Types;

/// <summary>
/// An object for transporting data in a convenient format, created for each <see cref="Telegram.Bot.Types.Update"/>
/// </summary>
public class TelegramContext
{
    public ITelegramBotClient BotClient { get; set; }
    public Update Update { get; set; }
    public UserStorageItem<long>? UserStorage { get; set; }
    public User? User { get; set; }
    public string? Data { get; set; }
    public CancellationToken Token { get; set; }
}