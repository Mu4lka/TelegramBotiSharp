using TelegramBotiSharp.Types;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Basic filter for routing updates to a specific <see cref="IUpdateTypeHandler"/>.
/// The search for a handler always stops when it passes the first matching set of filters.
/// By default, all handlers have an empty filter set, so all updates will be transmitted
/// to the first handler with an empty set of filters.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public abstract class FilterAttribute : Attribute
{
    /// <summary>
    /// This method determines whether the filter is passed or not
    /// </summary>
    /// <param name="context">Context</param>
    public abstract Task<bool> CallAsync(TelegramContext context);
}