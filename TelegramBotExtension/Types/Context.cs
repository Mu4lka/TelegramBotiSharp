using Telegram.Bot;
using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Types
{
    public abstract class Context
    {
        public ITelegramBotClient Bot { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public State State { get; set; }

        public string Data { get; set; }


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
