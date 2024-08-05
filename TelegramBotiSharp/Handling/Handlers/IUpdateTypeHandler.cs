using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.FiniteStateMachine;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling;

public interface IUpdateTypeHandler
{
    UpdateType UpdateType { get; }
    Task HandleUpdateAsync(TelegramContext context);
    TelegramContext GetContext(ITelegramBotClient botClient, IStorage storage, Update update);
}