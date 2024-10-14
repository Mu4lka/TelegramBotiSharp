namespace TelegramBotiSharp.Storages;

public interface IUserStorageItem
{
    Task SetStateAsync(string? state, CancellationToken token = default);
    Task<string?> GetStateAsync(CancellationToken token = default);
    Task UpdateDataAsync(string key, object value, CancellationToken token = default);
    Task UpdateDataAsync(Dictionary<string, object> data, CancellationToken token = default);
    Task SetDataAsync(Dictionary<string, object> data, CancellationToken token = default);
    Task<Dictionary<string, object>> GetDataAsync(CancellationToken token = default);
    Task<TData?> GetDataAsync<TData>(string key, CancellationToken token = default);
    Task ClearAsync(CancellationToken token = default);
}
