using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Types;

public class TelegramContext(
    ITelegramBotClient botClient,
    IUsersStorage<long> storage,
    Update update,
    User? user = null,
    string? data = default!,
    CancellationToken token = default!)
{
    public ITelegramBotClient BotClient { get; } = botClient;
    public Update Update { get; } = update;
    public UserStorageItem<long>? UserStorage { get; } = user is null ? null : new UserStorageItem<long>(user.Id, storage);
    public User? User { get; } = user;
    public string? Data { get; } = data;
    public CancellationToken Token = token;
}