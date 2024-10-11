namespace TelegramBotiSharp.Storages;

public interface IStorage<TId>
{
    Task SetStateAsync(TId id, string? state);
    Task<string?> GetStateAsync(TId id);
    Task UpdateDataAsync(TId id, string key, object value);
    Task UpdateDataAsync(TId id, Dictionary<string, object> data);
    Task SetDataAsync(TId id, Dictionary<string, object> data);
    Task<Dictionary<string, object>> GetDataAsync(TId id);
    Task<TData?> GetDataAsync<TData>(TId id, string key);
    Task ClearAsync(TId id);
}
