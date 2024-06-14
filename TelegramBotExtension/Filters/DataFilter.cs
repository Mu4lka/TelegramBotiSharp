using TelegramBotExtension.Types.Contexts;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Filters;

public class DataFilter(string? data) : FilterAttribute(data)
{
    public override Task<bool> Call(BaseContext baseContext)
    {
        bool result = false;
        if (baseContext is Context context)
            result = Data == context.Data;
        return Task.FromResult(result);
    }
}
