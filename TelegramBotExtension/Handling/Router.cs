using System.Reflection.Metadata;
using TelegramBotExtension.Handling.Handlers;

namespace TelegramBotExtension.Handling
{
    public class Router
    {
        public List<IHandler> Handlers { get; set; }

        public Router(List<IHandler> handlers)
        {
            Handlers = handlers;
        }

    }

}
