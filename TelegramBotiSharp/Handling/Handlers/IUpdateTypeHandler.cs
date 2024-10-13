using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

public interface IUpdateTypeHandler
{
    UpdateType UpdateType { get; }
    Task HandleAsync(TelegramContext context);
    TelegramContext GetContext(ITelegramBotClient botClient, IStorage<long> storage, Update update);
}