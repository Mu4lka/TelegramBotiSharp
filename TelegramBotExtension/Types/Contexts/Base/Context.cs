using Telegram.Bot;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Types.Contexts.Base;

public abstract class Context(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    long id,
    string? data
    ) : BaseContext(bot, cancellationToken)
{
    public State State { get; set; } = new State(id);

    public string? Data { get; set; } = data;
}
