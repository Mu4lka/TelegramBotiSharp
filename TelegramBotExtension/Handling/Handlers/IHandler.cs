using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers
{
    public interface IHandler
    {
        Task Execute(Context context);

    }

}
