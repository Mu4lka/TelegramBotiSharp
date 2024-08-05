namespace TelegramBotExtension.FiniteStateMachine;

public interface IStorage
{
    Task SetStateAsync(long id, string? state);
    Task<string?> GetStateAsync(long id);
    Task UpdateDataAsync(long id, string key, object value);
    Task UpdateDataAsync(long id, Dictionary<string, object> data);
    Task SetDataAsync(long id, Dictionary<string, object> data);
    Task<Dictionary<string, object>> GetDataAsync(long id);
    Task ClearAsync(long id);
}
