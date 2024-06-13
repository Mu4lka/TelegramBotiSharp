using Telegram.Bot;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Contexts;

namespace TelegramBotExtension.Examples;

enum State
{
    reg,
    isAdult
}

internal class RegistrationHandlers
{
    public static Router Router = new();

    static RegistrationHandlers()
    {
        Router.OnMessage += HandleCommandStart;
        Router.OnMessage += HandleGettingName;
        Router.OnCallbackQuery += ProcessIfAdult;
        Router.OnCallbackQuery += ProcessIfUnderage;
    }

    [Command("start")]
    public static async Task HandleCommandStart(MessageContext context)
    {
        await context.Bot.SendTextMessageAsync(
            context.Message.From!.Id,
            "Registration. Enter your name..."
            );
        await context.State.SetState(nameof(State.reg));
    }

    [StateFilter(nameof(State.reg))]
    public static async Task HandleGettingName(MessageContext context)
    {
        await context.State.UpdateData("name", context.Message.Text!);
        await context.Bot.SendTextMessageAsync(
            context.Message.From!.Id,
            "Are you over 18?",
            replyMarkup: UI.UI.GetInlineButtons(["Yes", "No"])
            );
        await context.State.SetState(nameof(State.isAdult));
    }

    [StateFilter(nameof(State.isAdult))]
    [DataFilter("Yes")]
    public static async Task ProcessIfAdult(CallbackQueryContext context)
    {
        var data = await context.State.GetData();
        await context.Bot.SendTextMessageAsync(
            context.CallbackQuery.From!.Id,
            $"{data["name"]}, Welcome!"
            );
        await context.State.Clear();
    }

    [StateFilter(nameof(State.isAdult))]
    [DataFilter("No")]
    public static async Task ProcessIfUnderage(CallbackQueryContext context)
    {
        var data = await context.State.GetData();
        await context.Bot.SendTextMessageAsync(
            context.CallbackQuery.From!.Id,
            $"{data["name"]}, Sorry but you're too young"
            );
        await context.State.Clear();
    }
}

internal class Program
{
    private const string _token = "TOKEN";
    private static readonly Dispatcher _dispatcher = new();

    public static async Task Main()
    {
        var botClient = new TelegramBotClient(_token);
        _dispatcher.Routers.Add(RegistrationHandlers.Router);
        await botClient.ReceiveAsync(_dispatcher);
    }
}
