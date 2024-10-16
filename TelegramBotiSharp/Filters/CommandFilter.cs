using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Filters.Exceptions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Filter for commands in chat for update type <see cref="UpdateType.Message"/>.
/// The <see cref="CallAsync"/> method will return <see langword="true"/> if the first entity 
/// message body is <see cref="MessageEntityType.BotCommand"/> with possible 
/// mention of a bot
/// </summary>
public class CommandFilter(string command) : FilterAttribute(command)
{
    private static string? BotUserName;

    public async override Task<bool> CallAsync(TelegramContext context, CancellationToken token = default)
    {
        var message = context.Update.Message
            ?? throw new InvalidFilterException($"The {nameof(CommandFilter)} applies only to the {nameof(Message)} type");

        if (message.Entities?.FirstOrDefault()?.Type is not MessageEntityType.BotCommand)
            return false;

        if (BotUserName is null)
        {
            var bot = await context.BotClient.GetMeAsync();
            BotUserName = $"@{bot.Username}";
        }

        if(message.Entities.Length > 1)
        {
            var mentions = message.Entities.Where(e => e.Type is MessageEntityType.Mention);
            var isBotMention = mentions.Any(m => message.Text!.Substring(m.Offset, m.Length) == BotUserName);

            if (!isBotMention) return false;
        }

        var command = message.Text![..message.Entities[0].Length];

        return command == $"/{Data}" || command == $"/{Data}{BotUserName}";
    }
}