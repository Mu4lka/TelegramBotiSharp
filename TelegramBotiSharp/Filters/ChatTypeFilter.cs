using System.Reflection;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotiSharp.Filters;
using TelegramBotiSharp.Filters.Exceptions;
using TelegramBotiSharp.Types;

namespace CodeGuruBot.Application.Filters;

/// <summary>
/// Filter by chat type
/// </summary>
/// <param name="_chatTypes">Chat types</param>
public class ChatTypeFilter(params ChatType[] _chatTypes) : FilterAttribute(null)
{
    public override Task<bool> CallAsync(TelegramContext context, CancellationToken token = default)
    {
        Type type = context.Update.GetType();

        PropertyInfo propertyInfo = type.GetProperty(context.Update.Type.ToString())
            ?? throw new InvalidFilterException($"There is no property with this update type {context.Update.Type}");

        var valueInUpdate = propertyInfo.GetValue(context.Update, null);

        Type propertyType = propertyInfo.PropertyType;

        PropertyInfo chatPropertyInfo = propertyType.GetProperties().FirstOrDefault(p => p.Name == "Chat")
            ?? throw new InvalidFilterException("Didn't find a property with type Chat");

        if (chatPropertyInfo.GetValue(valueInUpdate) is not Chat chat)
            throw new InvalidFilterException("The property found is not of type Chat");

        return Task.FromResult(_chatTypes.Any(type => chat.Type == type));
    }
}
