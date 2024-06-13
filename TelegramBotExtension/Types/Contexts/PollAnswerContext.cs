using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class PollAnswerContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    PollAnswer pollAnswer
    ) : Context(bot, cancellationToken, pollAnswer.User.Id, pollAnswer.PollId)
{
    public PollAnswer PollAnswer { get; set; } = pollAnswer;
}
