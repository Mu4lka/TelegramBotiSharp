namespace TelegramBotiSharp.Storages;

/// <summary>
/// Users storage
/// </summary>
/// <typeparam name="TUserId">User id</typeparam>
public interface IUsersStorage<TUserId> where TUserId : notnull
{
    /// <summary>
    /// Sets the state by user id
    /// </summary>
    /// <param name="id">User idr</param>
    /// <param name="state">State</param>
    /// <param name="token">Token</param>
    Task SetStateAsync(TUserId id, string? state, CancellationToken token = default);

    /// <summary>
    /// Get state by user id
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="token">Token</param>
    /// <returns>State</returns>
    Task<string?> GetStateAsync(TUserId id, CancellationToken token = default);

    /// <summary>
    /// Updates user data
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="key">Key</param>
    /// <param name="value">Value</param>
    /// <param name="token">Token</param>
    Task UpdateDataAsync(TUserId id, string key, object value, CancellationToken token = default);

    /// <summary>
    /// Updates user data
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="data">Data Dictionary</param>
    /// <param name="token">Token</param>
    Task UpdateDataAsync(TUserId id, Dictionary<string, object> data, CancellationToken token = default);

    /// <summary>
    /// Sets data to the user
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="data">Data Dictionary</param>
    /// <param name="token">Token</param>
    Task SetDataAsync(TUserId id, Dictionary<string, object> data, CancellationToken token = default);

    /// <summary>
    /// Get user data by id
    /// </summary>
    /// <param name="id">user id</param>
    /// <param name="token">Token</param>
    /// <returns>Data dictionary</returns>
    Task<Dictionary<string, object>> GetDataAsync(TUserId id, CancellationToken token = default);

    /// <summary>
    /// Get user data by id and data key
    /// </summary>
    /// <typeparam name="TData">Data</typeparam>
    /// <param name="id">User id</param>
    /// <param name="key">Key</param>
    /// <param name="token">Token</param>
    /// <returns>Data</returns>
    Task<TData?> GetDataAsync<TData>(TUserId id, string key, CancellationToken token = default);

    /// <summary>
    /// Clear user data and state
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="token">Token</param>
    Task ClearAsync(TUserId id, CancellationToken token = default);
}
