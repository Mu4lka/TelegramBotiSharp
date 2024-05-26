using Telegram.Bot;
using TelegramBotExtension.Handling.Handlers;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Examples
{
    [DataFilter("Hello")]
    internal class AnswerOnHello : MessageHandler
    {
        public override async Task Handle(MessageContext context)
        {
            await context.Bot.SendTextMessageAsync(context.Message.Chat.Id, "Answer Hello");
        }

    }

    internal class Program
    {
        private const string _token = "6539831617:AAHNXAUweXYg7Tnr84eIk91f_t4WxBxJAnU";

        public static async Task Main()
        {
            var botClient = new TelegramBotClient(_token);
            Router common = new Router(
                new List<IHandler>() { new AnswerOnHello(), }
                );
            Dispatcher handler = new Dispatcher();
            await botClient.ReceiveAsync(handler);
        }

    }

}
