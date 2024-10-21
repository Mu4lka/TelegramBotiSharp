using TelegramBotiSharp.Types;
using TelegramBotiSharp.Storages;
using TelegramBotiSharp.Filters.Exceptions;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// A filter that checks the equality of the user's saved state in <see cref="UserStorageItem{T}"/> 
/// and the specified state
/// </summary>
/// <param name="state">State</param>
public class StateFilter(string? _state) : FilterAttribute
{
    public override async Task<bool> CallAsync(TelegramContext context)
    {
        if (context.UserStorage is null)
            throw new InvalidFilterException($"{nameof(context.UserStorage)} is null");

        return await context.UserStorage.GetStateAsync() == _state;
    }
}