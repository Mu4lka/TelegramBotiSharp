using TelegramBotiSharp.Types;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// A filter that checks the equality of the user's saved state in <see cref="UserStorageItem{T}"/> 
/// and the specified state in <see cref="FilterAttribute.Data"/>
/// </summary>
/// <param name="state">State</param>
public class StateFilter(string? state) : FilterAttribute(state)
{
    public override async Task<bool> CallAsync(TelegramContext context)
    {
        if (context.UserStorage is null)
            return false;

        return await context.UserStorage.GetStateAsync() == Data;
    }
}
