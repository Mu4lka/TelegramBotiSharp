using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Filters;

public class DataFilter(string? data) : FilterAttribute(data)
{
    public override Task<bool> Call(Context context)
    {
        return Task.FromResult(Data == context.Data);
    }
}
