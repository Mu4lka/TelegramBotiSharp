using System.Collections.Concurrent;

namespace TelegramBotiSharp.Storages;

public class MemoryStorage : IStorage<long>
{
    private readonly ConcurrentDictionary<long, string?> _states = [];
    private readonly ConcurrentDictionary<long, ConcurrentDictionary<string, object>> _data = [];

    public Task SetStateAsync(long id, string? state)
    {
        _states[id] = state;
        return Task.CompletedTask;
    }

    public Task<string?> GetStateAsync(long id)
    {
        _states.TryGetValue(id, out var state);
        return Task.FromResult(state);
    }

    public Task UpdateDataAsync(long id, string key, object value)
    {
        return Task.Run(() =>
        {
            _data.AddOrUpdate(
                id,
                new ConcurrentDictionary<string, object>([new KeyValuePair<string, object>(key, value)]),
                (existingId, existingData) =>
                {
                    existingData[key] = value;
                    return existingData;
                });
        });
    }

    public async Task UpdateDataAsync(long id, Dictionary<string, object> data)
    {
        foreach (var item in data)
            await UpdateDataAsync(id, item.Key, item.Value);
    }

    public Task SetDataAsync(long id, Dictionary<string, object> data)
    {
        _data[id] = new ConcurrentDictionary<string, object>(data);
        return Task.CompletedTask;
    }

    public Task<Dictionary<string, object>> GetDataAsync(long id)
    {
        if (_data.TryGetValue(id, out var data))
            return Task.FromResult(data.ToDictionary());

        return Task.FromResult(new Dictionary<string, object>());
    }

    public Task<TData?> GetDataAsync<TData>(long id, string key)
    {
        if (!_data.TryGetValue(id, out var dictData))
            return Task.FromResult(default(TData?));

        if (!dictData.TryGetValue(key, out object? obj))
            return Task.FromResult(default(TData?));

        if (obj is TData data)
            return Task.FromResult(data)!;

        return Task.FromResult(default(TData?));
    }

    public Task ClearAsync(long id)
    {
        _states.TryRemove(id, out var _);
        _data.TryRemove(id, out var _);
        return Task.CompletedTask;
    }
}
