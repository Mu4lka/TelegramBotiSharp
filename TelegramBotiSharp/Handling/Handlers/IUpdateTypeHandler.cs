using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;
using TelegramBotiSharp.Storages;

namespace TelegramBotExtension.Handling;

public interface IUpdateTypeHandler
{
    UpdateType UpdateType { get; }
    Task HandleUpdateAsync(TelegramContext context);
    TelegramContext GetContext(ITelegramBotClient botClient, IStorage<long> storage, Update update);
}