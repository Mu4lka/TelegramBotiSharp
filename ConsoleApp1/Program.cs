// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using TelegramBotExtension.Handling;
using TelegramBotExtension.Types;

Console.WriteLine("Hello, World!");


class CommonHandler : MessageHandler
{
    public override Task HandleUpdateAsync(TelegramContext context)
    {
        throw new NotImplementedException();
    }
}