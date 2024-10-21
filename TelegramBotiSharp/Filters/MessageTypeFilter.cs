using System.Reflection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Filters.Exceptions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Filter on <see cref="MessageType"/>
/// </summary>
/// <param name="messageTypes">Message types</param>
public class MessageTypeFilter(params MessageType[] messageTypes) : FilterAttribute
{
    public override Task<bool> CallAsync(TelegramContext context)
    {
        Type type = context.Update.GetType();

        PropertyInfo propertyInfo = type.GetProperty(context.Update.Type.ToString())
            ?? throw new InvalidFilterException($"A property named {context.Update.Type} was not found");

        if (propertyInfo.GetValue(context.Update) is not Message message)
            throw new InvalidFilterException($"This update type is not a {typeof(Message).FullName}");

        var a = message.Type;

        return Task.FromResult(messageTypes.Any(t => t == message.Type));
    }
}
