using Telegram.Bot;
using TelegramBotExtension.Handling.Handlers;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Examples
{
    [CastomFilter()]
    [DataFilter("Hello")]
    internal class AnswerOnHello : MessageHandler
    {
        public override async Task Handle(MessageContext context)
        {
            string[] buttons = { "Hello", "Print" };
            var inlineButtons = UI.UI.GetInlineButtons(buttons);
            await context.Bot.SendTextMessageAsync(context.Message.Chat.Id, "Answer Hello", replyMarkup: inlineButtons);
        }

    }

    [DataFilter("Print")]
    internal class AnswerPrint : CallbackQueryHandler
    {
        public override async Task Handle(CallbackQueryContext context)
        {
            await context.Bot.SendTextMessageAsync(context.CallbackQuery.From.Id, "Answer Print");
        }
    }

    [Command("start")]
    internal class CommandStart : MessageHandler
    {
        public override async Task Handle(MessageContext context)
        {
            await context.Bot.SendTextMessageAsync(context.Message.From.Id, "start");
        }
    }

    internal class AnswerOnCallbackQuery : CallbackQueryHandler
    {
        public override async Task Handle(CallbackQueryContext context)
        {
            await context.Bot.SendTextMessageAsync(context.CallbackQuery.From.Id, context.Data);
        }
    }

    internal class Program
    {
        private const string _token = "6562055962:AAEqE9F-vbMxHsRPx_BbjrKBrO2hBVcnT_o";

        public static async Task Main()
        {
            var botClient = new TelegramBotClient(_token);
            Router common = new Router(
                new List<IHandler>() {
                    new AnswerOnHello(),
                    new AnswerPrint(),
                    new AnswerOnCallbackQuery(),
                    new CommandStart(),

                });
            Dispatcher dispatcher = new Dispatcher();
            dispatcher.Routers.Add(common);
            await botClient.ReceiveAsync(dispatcher);
        }

    }

}
