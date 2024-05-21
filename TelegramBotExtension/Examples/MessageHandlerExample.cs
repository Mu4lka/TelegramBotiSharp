using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Handling.Routers;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Examples
{
    [StateFilter("state")]
    internal class MessageHandlerExample : IMessageHandler
    {
        public Task HandleMessage(MessageContext context)
        {
            throw new NotImplementedException();
        }

    }

    [StateFilter("state2")]
    internal class MessageHandlerExample2 : IMessageHandler
    {
        public Task HandleMessage(MessageContext context)
        {
            throw new NotImplementedException();
        }

    }

    [StateFilter("state3")]
    internal class CallbackQueryHandlerState3 : ICallbackQueryHandler
    {
        public async Task HandleCallbackQuery(CallbackQueryContext context)
        {
            await context.Bot.SendTextMessageAsync(
                context.CallbackQuery.Message.Chat.Id,
                "Вызван обработчик CallbackQueryHandlerState3"
                );
            context.State.SetState("state4");
        }

    }

    [StateFilter("state4")]
    internal class CallbackQueryHandlerState4 : ICallbackQueryHandler
    {
        public async Task HandleCallbackQuery(CallbackQueryContext context)
        {
            await context.Bot.SendTextMessageAsync(
                context.CallbackQuery.Message.Chat.Id,
                "Вызван обработчик CallbackQueryHandlerState4"
                );
            context.State.Clear();
        }

        public static InlineKeyboardMarkup GetInLineButtons(string[] buttons)
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>();

            foreach (var button in buttons)
                inlineKeyboardButtons.Add(new List<InlineKeyboardButton> { new InlineKeyboardButton(button) { CallbackData = button } });

            return new InlineKeyboardMarkup(inlineKeyboardButtons);
        }

    }

}
