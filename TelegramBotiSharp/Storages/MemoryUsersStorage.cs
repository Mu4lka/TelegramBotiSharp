using System.Collections.Concurrent;

namespace TelegramBotiSharp.Storages;

/// <summary>
/// Implementation of <see cref="IUsersStorage{TUserId}"/>, where data is stored in service memory
/// </summary>
public class MemoryUsersStorage<TUserId> : IUsersStorage<TUserId> where TUserId : notnull
{
    private readonly ConcurrentDictionary<TUserId, string?> _states = [];
    private readonly ConcurrentDictionary<TUserId, ConcurrentDictionary<string, object>> _data = [];

    public Task SetStateAsync(TUserId id, string? state, CancellationToken token = default!)
    {
        _states[id] = state;
        return Task.CompletedTask;
    }

    public Task<string?> GetStateAsync(TUserId id, CancellationToken token = default)
    {
        _states.TryGetValue(id, out var state);
        return Task.FromResult(state);
    }

    public Task UpdateDataAsync(TUserId id, string key, object value, CancellationToken token = default)
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
        }, token);
    }

    public async Task UpdateDataAsync(TUserId id, Dictionary<string, object> data, CancellationToken token = default)
    {
        foreach (var item in data)
            await UpdateDataAsync(id, item.Key, item.Value, token);
    }

    public Task SetDataAsync(TUserId id, Dictionary<string, object> data, CancellationToken token = default)
    {
        _data[id] = new ConcurrentDictionary<string, object>(data);
        return Task.CompletedTask;
    }

    public Task<Dictionary<string, object>> GetDataAsync(TUserId id, CancellationToken token = default)
    {
        if (_data.TryGetValue(id, out var data))
            return Task.FromResult(data.ToDictionary());

        return Task.FromResult(new Dictionary<string, object>());
    }

    public Task<TData?> GetDataAsync<TData>(TUserId id, string key, CancellationToken token = default)
    {
        if (!_data.TryGetValue(id, out var dictData))
            return Task.FromResult(default(TData?));

        if (!dictData.TryGetValue(key, out object? obj))
            return Task.FromResult(default(TData?));

        if (obj is TData data)
            return Task.FromResult(data)!;

        return Task.FromResult(default(TData?));
    }

    public Task ClearAsync(TUserId id, CancellationToken token = default)
    {
        _states.TryRemove(id, out var _);
        _data.TryRemove(id, out var _);
        return Task.CompletedTask;
    }
}
