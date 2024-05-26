using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Handling.Handlers
{
    public interface IHandler
    {
        Task Execute(Context context);

    }

}
