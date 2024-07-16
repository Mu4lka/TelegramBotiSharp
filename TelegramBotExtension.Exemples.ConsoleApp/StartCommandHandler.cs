using Telegram.Bot;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Exemples.ConsoleApp;

internal class StartCommandHandler : MessageHandler
{
    [Command("start")]
    public override async Task HandleUpdateAsync(TelegramContext context)
    {
        await context.BotClient.SendTextMessageAsync(context.UserId, "Hello, World!");
    }
}
