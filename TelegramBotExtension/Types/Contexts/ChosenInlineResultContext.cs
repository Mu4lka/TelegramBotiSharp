using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class ChosenInlineResultContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    ChosenInlineResult chosenInlineResult
    ) : Context(bot, cancellationToken, chosenInlineResult.From.Id, chosenInlineResult.Query)
{
    public ChosenInlineResult ChosenInlineResult { get; set; } = chosenInlineResult;
}
