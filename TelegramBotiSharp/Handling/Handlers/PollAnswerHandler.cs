using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Handling.Handlers;

/// <summary>
/// <see cref="Update.PollAnswer"/> handler
/// </summary>
public abstract class PollAnswerHandler : IUpdateTypeHandler
{
    public UpdateType UpdateType => UpdateType.PollAnswer;

    public TelegramContext GetContext(ITelegramBotClient botClient, IUsersStorage<long> storage, Update update)
        => new(botClient, storage, update, update.PollAnswer!.User);

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => new(
            builder.BotClient,
            builder.Storage,
            builder.Update,
            builder.Update.PollAnswer!.User,
            null,
            builder.Token);

    public abstract Task HandleAsync(TelegramContext context);
}
