namespace TelegramBotiSharp.Storages;

public class UserStorageItem<TUserId>(TUserId _id, IUsersStorage<TUserId> _storage) : IUserStorageItem where TUserId : notnull
{
    public Task SetStateAsync(string? state, CancellationToken token = default) => _storage.SetStateAsync(_id, state, token);

    public Task<string?> GetStateAsync(CancellationToken token = default) => _storage.GetStateAsync(_id, token);

    public Task UpdateDataAsync(string key, object value, CancellationToken token = default) => _storage.UpdateDataAsync(_id, key, value, token);

    public Task UpdateDataAsync(Dictionary<string, object> data, CancellationToken token = default) => _storage.UpdateDataAsync(_id, data, token);

    public Task SetDataAsync(Dictionary<string, object> data, CancellationToken token = default) => _storage.SetDataAsync(_id, data, token);

    public Task<Dictionary<string, object>> GetDataAsync(CancellationToken token = default) => _storage.GetDataAsync(_id, token);

    public Task ClearAsync(CancellationToken token = default) => _storage.ClearAsync(_id, token);

    public Task<TData?> GetDataAsync<TData>(string key, CancellationToken token = default) => _storage.GetDataAsync<TData>(_id, key, token);
}
