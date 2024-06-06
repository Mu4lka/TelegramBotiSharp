# TelegramBotExtension
**TelegramBotExtension** is a library (extension) over [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) on **.NET 8.0**, for the convenience of writing telegram bots in **C#**.

## Advantages

* Easy creation of handlers. Here is an example of a handler that processes the /start command:


        [Command("start")]
        public static async Task HandleCommandStart(MessageContext context)
        {
            await context.Bot.SendTextMessageAsync(
                context.Message.From!.Id,
                "Registration. Enter your name..."
                );
        }

These handlers (methods) must subscribe to the corresponding events that are defined in the Router class or in the Dispatcher:

    internal class HandlersExemples
    {
        public static Router Router = new();

        static RegistrationHandlers()
        {
            Router.OnMessage += HandleCommandStart;
        }

        [Command("start")]
        public static async Task HandleCommandStart(MessageContext context)
        {
            await context.Bot.SendTextMessageAsync(
                context.Message.From!.Id,
                "Registration. Enter your name..."
                );
        }

    }

    internal class Program
    {
        private const string _token = "YOUR_TOKEN";
        private static readonly Dispatcher _dispatcher = new();

        public static async Task Main()
        {
            var botClient = new TelegramBotClient(_token);
            _dispatcher.Routers.Add(RegistrationHandlers.Router);
            await botClient.ReceiveAsync(_dispatcher);
        }

    }
Detailed examples in the [file](https://github.com/Mu4lka/TelegramBotExtension/blob/master/TelegramBotExtension.Examples/HandlersExamples.cs).

* Handlers can have filters (attributes), if all filters are passed, then this handler will be called
* The state machine is implemented, and you can also override its storage
* You can create custom filters that inherit from the FilterAttribute class:


    internal class CastomFilter : FilterAttribute
    {
        public CastomFilter() : base(null) { }

        public override async Task<bool> Call(Context context)
        {
            if (context is not MessageContext messageContext)
                return false;
            
            if (messageContext.Message.From == null)
                return false;

            User user = messageContext.Message.From;

            await context.Bot.SendTextMessageAsync(user.Id, "CastomFilter");
            return true;
        }

    }

#### Not all types of telegram objects are supported yet, this project will continue to be supported and improved