using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;

namespace TelegramBotiSharp.Types;

/// <summary>
/// Object for creating <see cref="TelegramContext"/> in <see cref="IUpdateTypeHandler"/>
/// </summary>
public record TelegramContextBuilder(
    ITelegramBotClient BotClient,
    IUsersStorage<long> Storage,
    Update Update,
    CancellationToken Token = default!
    );
