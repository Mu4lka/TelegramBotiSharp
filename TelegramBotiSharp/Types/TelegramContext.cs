using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Types;

public class TelegramContext(
    ITelegramBotClient botClient,
    IStorage storage,
    Update update,
    long userId,
    string data
)
{
    public ITelegramBotClient BotClient { get; set; } = botClient;
    public Update Update { get; set; } = update;
    public IUserStorage UserStorage { get; set; } = new UserStorage(userId, storage);
    public long UserId { get; set; } = userId;
    public string Data { get; set; } = data;
}