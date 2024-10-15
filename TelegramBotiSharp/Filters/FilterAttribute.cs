using TelegramBotiSharp.Types;
using TelegramBotiSharp.Handling.Handlers.Abstrаctions;

namespace TelegramBotiSharp.Filters;

/// <summary>
/// Basic filter for routing updates to a specific <see cref="IUpdateTypeHandler"/>.
/// The search for a handler always stops when it passes the first matching set of filters.
/// By default, all handlers have an empty filter set, so all updates will be transmitted
/// to the first handler with an empty set of filters.
/// </summary>
/// <param name="data">Data</param>
[AttributeUsage(AttributeTargets.Method)]
public abstract class FilterAttribute(string? data) : Attribute
{
    /// <summary>
    /// Data
    /// </summary>
    public string? Data { get; } = data;

    /// <summary>
    /// Method, the result of which will be passing the filter. 
    /// Returns <see cref="Task"/> whose result will be <see langword="true"/>, 
    /// if the filter is passed, otherwise <see langword="false"/>
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="token">Token</param>
    public abstract Task<bool> CallAsync(TelegramContext context, CancellationToken token = default);
}