using Telegram.Bot;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Examples
{
    internal class RegistrationHandlers
    {
        public static Router Router = new Router();

        public static void Handle(MessageContext context)
        {
            context.Bot.SendTextMessageAsync(context.Message.From!.Id, "Hello");
        }

        [Command("start")]
        public static void HandleCommandStart(MessageContext context)
        {
            context.Bot.SendTextMessageAsync(context.Message.From!.Id, "Registration. Enter your name...");
            context.State.SetState("name");
        }

        [StateFilter("name")]
        public static void HandleGettingName(MessageContext context)
        {
            context.State.UpdateData(("name", context.Message.Text!));
            context.Bot.SendTextMessageAsync(
                context.Message.From!.Id,
                "Are you over 18?",
                replyMarkup: UI.UI.GetInlineButtons(["Yes", "No"])
                );
            context.State.SetState("isAdult");
        }

        [StateFilter("isAdult")]
        [DataFilter("Yes")]
        public static void ProcessIfAdult(CallbackQueryContext context)
        {
            var name = (string)context.State.GetData()["name"];
            context.Bot.SendTextMessageAsync(context.CallbackQuery.From!.Id, $"{name}, Welcome!");
            context.State.Clear();
        }

        [StateFilter("isAdult")]
        [DataFilter("No")]
        public static void ProcessIfUnderage(CallbackQueryContext context)
        {
            var name = (string)context.State.GetData()["name"];
            context.Bot.SendTextMessageAsync(context.CallbackQuery.From!.Id, $"{name}, Sorry but you're too young");
            context.State.Clear();
        }

        public static void Subscribe()
        {
            Router.OnMessage += HandleCommandStart;
            Router.OnMessage += HandleGettingName;
            Router.OnCallbackQuery += ProcessIfAdult;
            Router.OnCallbackQuery += ProcessIfUnderage;
            Router.OnMessage += Handle;
        }

    }

    internal class Program
    {
        private const string _token = "6562055962:AAEqE9F-vbMxHsRPx_BbjrKBrO2hBVcnT_o";

        public static async Task Main()
        {
            var botClient = new TelegramBotClient(_token);
            RegistrationHandlers.Subscribe();
            await botClient.ReceiveAsync(RegistrationHandlers.Router);
        }

    }

}
