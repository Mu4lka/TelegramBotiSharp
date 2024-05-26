using Telegram.Bot;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Examples
{
    internal class Program
    {
        private const string _token = "6562055962:AAEqE9F-vbMxHsRPx_BbjrKBrO2hBVcnT_o";

        public static async Task Main()
        {
            var botClient = new TelegramBotClient(_token);
            Dispatcher dispatcher = new Dispatcher();

            dispatcher.OnMessage += HandleMessage1;
            dispatcher.OnMessage += HandleMessage2;
            dispatcher.OnMessage += HandleMessage3;

            await botClient.ReceiveAsync(dispatcher);
        }

        [StateFilter(null)]
        public static void HandleMessage1(MessageContext context)
        {
            context.Bot.SendTextMessageAsync(context.Message.From.Id, "Один");
            context.State.SetState("2");
        }

        [StateFilter("2")]
        public static void HandleMessage2(MessageContext context)
        {
            context.Bot.SendTextMessageAsync(context.Message.From.Id, "Два");
            context.State.SetState("3");
        }

        [StateFilter("3")]
        public static void HandleMessage3(MessageContext context)
        {
            context.Bot.SendTextMessageAsync(context.Message.From.Id, "Три");
            context.State.SetState(null);
        }

    }

}
