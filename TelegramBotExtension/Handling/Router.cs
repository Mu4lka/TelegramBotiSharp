using TelegramBotExtension.Handling.Handlers;

namespace TelegramBotExtension.Handling
{
    public class Router
    {
        public List<Handler> Handlers;

        public Router(List<Handler> handlers)
        {
            Handlers = handlers;
        }

    }

}
