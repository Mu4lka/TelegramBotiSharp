using System.Reflection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Filters.Exceptions;
using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Filter on <see cref="ChatType"/>
/// </summary>
/// <param name="_chatTypes">Chat types</param>
public class ChatTypeFilter(params ChatType[] _chatTypes) : FilterAttribute
{
    public override Task<bool> CallAsync(TelegramContext context)
    {
        Type type = context.Update.GetType();

        PropertyInfo propertyInfo = type.GetProperty(context.Update.Type.ToString())
            ?? throw new InvalidFilterException($"A property named {context.Update.Type} was not found");

        var valueInUpdate = propertyInfo.GetValue(context.Update, null);

        Type propertyType = propertyInfo.PropertyType;

        PropertyInfo chatPropertyInfo = propertyType.GetProperties().FirstOrDefault(p => p.Name == "Chat")
            ?? throw new InvalidFilterException("Inappropriate update type. It doesn't contain a property named Chat");

        if (chatPropertyInfo.GetValue(valueInUpdate) is not Chat chat)
            throw new InvalidFilterException("Property named Chat does not match type Chat");

        return Task.FromResult(_chatTypes.Any(type => chat.Type == type));
    }
}
