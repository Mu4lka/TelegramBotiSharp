using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Handling.Handlers;

public abstract class CallbackQueryHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.CallbackQuery;

    public abstract Task HandleUpdateAsync(TelegramContext context);

    public TelegramContext GetContext(ITelegramBotClient botClient, Update update)
        => new(botClient,update,update.CallbackQuery!.From.Id,update.CallbackQuery.Data!);
}
