using Telegram.Bot.Types;
using Telegram.Bot;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class ChatJoinRequestContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    ChatJoinRequest chatJoinRequest
    ) : Context(bot, cancellationToken, chatJoinRequest.From.Id, chatJoinRequest.Bio)
{
    public ChatJoinRequest ChatJoinRequest { get; set; } = chatJoinRequest;
}
