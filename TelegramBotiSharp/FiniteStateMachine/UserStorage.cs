namespace TelegramBotExtension.FiniteStateMachine;

public class UserStorage(long _id, IStorage<long> _storage) : IUserStorage
{
    public Task SetStateAsync(string? state) => _storage.SetStateAsync(_id, state);

    public Task<string?> GetStateAsync() => _storage.GetStateAsync(_id);

    public Task UpdateDataAsync(string key, object value) => _storage.UpdateDataAsync(_id, key, value);

    public Task UpdateDataAsync(Dictionary<string, object> data) => _storage.UpdateDataAsync(_id, data);

    public Task SetDataAsync(Dictionary<string, object> data) => _storage.SetDataAsync(_id, data);

    public Task<Dictionary<string, object>> GetDataAsync() => _storage.GetDataAsync(_id);

    public Task ClearAsync() => _storage.ClearAsync(_id);

    public Task<TData?> GetDataAsync<TData>(string key) => _storage.GetDataAsync<TData>(_id, key);
}
