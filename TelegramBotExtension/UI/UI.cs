using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExtension.UI;

public class UI
{
    public static InlineKeyboardMarkup GetInlineButtons(string[] buttons)
    {
        var inlineKeyboardButtons = new List<List<InlineKeyboardButton>>();

        foreach (var button in buttons)
            inlineKeyboardButtons.Add([new(button) { CallbackData = button }]);

        return new InlineKeyboardMarkup(inlineKeyboardButtons);
    }
}
