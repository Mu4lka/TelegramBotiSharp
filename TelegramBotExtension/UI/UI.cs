using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExtension.UI
{
    public class UI
    {
        public static InlineKeyboardMarkup FromInlineButtons(string[] buttons)
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>();

            foreach (var button in buttons)
                inlineKeyboardButtons.Add(new List<InlineKeyboardButton> { new InlineKeyboardButton(button) { CallbackData = button } });

            return new InlineKeyboardMarkup(inlineKeyboardButtons);
        }

    }

}
