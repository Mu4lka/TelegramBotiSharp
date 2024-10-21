using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Filters.Exceptions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Filter on command
/// </summary>
public class CommandFilter : FilterAttribute
{
    private static string? _botUserName;
    private readonly string _command;

    public CommandFilter(string command)
    {
        ArgumentNullException.ThrowIfNull(command, nameof(command));

        _command = command[0] == '/' ? command : '/' + command;
    }

    public async override Task<bool> CallAsync(TelegramContext context)
    {
        var message = context.Update.Message
            ?? throw new InvalidFilterException($"The {nameof(CommandFilter)} applies only to the {nameof(Message)} type");

        if (message.Entities?.FirstOrDefault()?.Type is not MessageEntityType.BotCommand)
            return false;

        if (_botUserName is null)
        {
            var bot = await context.BotClient.GetMeAsync();
            _botUserName = $"@{bot.Username}";
        }

        if(message.Entities.Length > 1)
        {
            var mentions = message.Entities.Where(e => e.Type is MessageEntityType.Mention);
            var isBotMention = mentions.Any(m => message.Text!.Substring(m.Offset, m.Length) == _botUserName);

            if (!isBotMention) return false;
        }

        var command = message.Text![..message.Entities[0].Length];

        return command == _command || command == $"{_command}{_botUserName}";
    }
}