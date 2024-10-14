using TelegramBotiSharp.Types;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Фильтр, проверяющий на равенство <see cref="FilterAttribute.Data"/>
/// и <see cref="TelegramContext.Data"/>
/// </summary>
/// <param name="data">Данные</param>
public class DataFilter(string? data) : FilterAttribute(data)
{
    public override Task<bool> CallAsync(TelegramContext context)
        => Task.FromResult(Data == context.Data);
}
