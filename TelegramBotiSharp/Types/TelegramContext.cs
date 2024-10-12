using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotiSharp.Storages;

namespace TelegramBotExtension.Types;

public class TelegramContext(
    ITelegramBotClient botClient,
    IStorage<long> storage,
    Update update,
    User user,
    string data)
{
    public ITelegramBotClient BotClient { get; } = botClient;
    public Update Update { get; } = update;
    public UserStorage<long> UserStorage { get; } = new UserStorage<long>(user.Id, storage);
    public User User { get; } = user;
    public string Data { get; } = data;
}