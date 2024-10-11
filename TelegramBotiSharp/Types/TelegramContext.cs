using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotiSharp.Storages;

namespace TelegramBotExtension.Types;

public class TelegramContext(
    ITelegramBotClient botClient,
    IStorage<long> storage,
    Update update,
    User user,
    string data
)
{
    public ITelegramBotClient BotClient { get; set; } = botClient;
    public Update Update { get; set; } = update;
    public IUserStorage UserStorage { get; set; } = new UserStorage(user.Id, storage);
    public User User { get; set; } = user;
    public string Data { get; set; } = data;
}