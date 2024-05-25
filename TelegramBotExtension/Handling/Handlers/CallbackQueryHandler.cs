using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public abstract class CallbackQueryHandler
    {
        public abstract Task HandleCallbackQuery(CallbackQueryContext context);
    }


}
