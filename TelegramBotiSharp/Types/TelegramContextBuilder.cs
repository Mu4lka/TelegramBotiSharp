using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Types;

public record TelegramContextBuilder(
    ITelegramBotClient BotClient,
    IUsersStorage<long> Storage,
    Update Update,
    CancellationToken Token = default!
    );
