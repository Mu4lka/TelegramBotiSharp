using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// 
/// </summary>
/// <param name="data">Data</param>
public class DataFilter(string? _data) : FilterAttribute
{
    public override Task<bool> CallAsync(TelegramContext context)
        => Task.FromResult(_data == context.Data);
}
