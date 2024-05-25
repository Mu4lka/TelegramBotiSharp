using Telegram.Bot;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Types
{
    public abstract class Context
    {
        public ITelegramBotClient Bot;
        public CancellationToken CancellationToken;
        public State State;
        public string Data;

        public Context(
            ITelegramBotClient bot,
            CancellationToken cancellationToken,
            long id,
            string data
            )
        {
            Bot = bot;
            CancellationToken = cancellationToken;
            State = new State(id);
            Data = data;
        }

    }

}
