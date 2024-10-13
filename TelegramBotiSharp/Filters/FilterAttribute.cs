using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

[AttributeUsage(AttributeTargets.Method)]
public abstract class FilterAttribute(string? data) : Attribute
{
    public string? Data { get; } = data;

    public abstract Task<bool> CallAsync(TelegramContext context);
}
