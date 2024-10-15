namespace TelegramBotiSharp.Storages;

/// <summary>
/// <see cref="IUsersStorage{T}"/> item. This object that provides access to user-specified storage.
/// </summary>
/// <typeparam name="TUserId">User Id</typeparam>
/// <param name="_id">User Id</param>
/// <param name="_storage">User storage</param>
public class UserStorageItem<TUserId>(TUserId _id, IUsersStorage<TUserId> _storage) where TUserId : notnull
{
    /// <summary>
    /// Sets user state
    /// </summary>
    /// <param name="state">State</param>
    /// <param name="token">Token</param>
    public Task SetStateAsync(string? state, CancellationToken token = default)
        => _storage.SetStateAsync(_id, state, token);

    /// <summary>
    /// Gets user state
    /// </summary>
    /// <param name="token">Token</param>
    /// <returns>State</returns>
    public Task<string?> GetStateAsync(CancellationToken token = default)
        => _storage.GetStateAsync(_id, token);

    /// <summary>
    /// Updates user data by data key
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Data</param>
    /// <param name="token">Token</param>
    public Task UpdateDataAsync(string key, object value, CancellationToken token = default)
        => _storage.UpdateDataAsync(_id, key, value, token);

    /// <summary>
    /// Updates the user's data dictionary
    /// </summary>
    /// <param name="data">Data</param>
    /// <param name="token">Token</param>
    public Task UpdateDataAsync(Dictionary<string, object> data, CancellationToken token = default)
        => _storage.UpdateDataAsync(_id, data, token);

    /// <summary>
    /// Sets data dictionary to user
    /// </summary>
    /// <param name="data">Dictionary data</param>
    /// <param name="token">Token</param>
    public Task SetDataAsync(Dictionary<string, object> data, CancellationToken token = default)
        => _storage.SetDataAsync(_id, data, token);

    /// <summary>
    /// Get user data dictionary
    /// </summary>
    /// <param name="token">Token</param>
    /// <returns>Dictionary data</returns>
    public Task<Dictionary<string, object>> GetDataAsync(CancellationToken token = default)
        => _storage.GetDataAsync(_id, token);

    /// <summary>
    /// Get user data by data key
    /// </summary>
    /// <typeparam name="TData">Data</typeparam>
    /// <param name="key">Key</param>
    /// <param name="token">Token</param>
    /// <returns>Data</returns>
    public Task<TData?> GetDataAsync<TData>(string key, CancellationToken token = default)
        => _storage.GetDataAsync<TData>(_id, key, token);

    /// <summary>
    /// Clears user data and user state
    /// </summary>
    /// <param name="token">Token</param>
    public Task ClearAsync(CancellationToken token = default)
        => _storage.ClearAsync(_id, token);
}
