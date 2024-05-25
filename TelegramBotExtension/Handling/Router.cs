using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBotExtension.Handling
{
    public class Router
    {
        public List<IHandler> Handlers;

        public Router(List<IHandler> handlers)
        {
            Handlers = handlers;
        }
    }
}
