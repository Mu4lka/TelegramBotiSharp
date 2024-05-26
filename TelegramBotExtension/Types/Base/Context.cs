using Telegram.Bot;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Types.Base
{
    public abstract class Context : BaseContext
    {
        public State State { get; set; }

        public string Data { get; set; }

        public Context(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            long id,
            string data
            ) : base(bot, cancellationToken)
        {
            State = new State(id);
            Data = data;
        }

    }

}
