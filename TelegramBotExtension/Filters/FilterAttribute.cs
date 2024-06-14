using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Filters;

[AttributeUsage(AttributeTargets.Method)]
public abstract class FilterAttribute(string? data) : Attribute
{
    public string? Data { get; set; } = data;

    public abstract Task<bool> Call(BaseContext baseContext);
}
