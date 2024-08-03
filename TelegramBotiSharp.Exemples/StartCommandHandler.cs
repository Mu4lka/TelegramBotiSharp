using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Exemples.ConsoleApp;

internal class StartCommandHandler : MessageHandler
{
    [CommandFilter("start")]
    public override async Task HandleUpdateAsync(TelegramContext context)
    {
        await context.BotClient.SendTextMessageAsync(context.UserId, "Hello, World!");
    }
}
