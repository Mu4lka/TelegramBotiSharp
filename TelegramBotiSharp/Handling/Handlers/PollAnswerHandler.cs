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

    public TelegramContext GetContext(TelegramContextBuilder builder)
        => builder
            .WithUser(u => u.PollAnswer!.User!)
            .WithData(u => u.PollAnswer!.PollId)
            .WithUserStorageItem(u => u.PollAnswer!.User!.Id)
            .Build();

    public abstract Task HandleAsync(TelegramContext context);
}
