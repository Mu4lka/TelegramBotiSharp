using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

public class DataFilter(string? data) : FilterAttribute(data)
{
    public override Task<bool> CallAsync(TelegramContext context)
        => Task.FromResult(Data == context.Data);
}
