using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotExtension.UI;

public static class KeyboardMarkup
{
    public static InlineKeyboardMarkup GetInlineKeyboardMarkup<T1, T2>(
        this IEnumerable<(T1, T2)> buttons,
        Func<(T1, T2), IEnumerable<InlineKeyboardButton>> func)
        => new(buttons.Select(func));

    public static InlineKeyboardMarkup GetInlineKeyboardMarkup<T1, T2>(
        this IEnumerable<(T1, T2)> buttons,
        Func<(T1, T2), InlineKeyboardButton> func)
        => new(buttons.Select(func));

    public static ReplyKeyboardMarkup GetReplyKeyboardMarkup<T>(
        this IEnumerable<T> buttons,
        Func<T, IEnumerable<KeyboardButton>> func)
        => new(buttons.Select(func));

    public static ReplyKeyboardMarkup GetReplyKeyboardMarkup<T>(
        this IEnumerable<T> buttons,
        Func<T, KeyboardButton> func)
        => new(buttons.Select(func));
}
