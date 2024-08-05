namespace TelegramBotExtension.FiniteStateMachine;

public interface IUserStorage
{
    Task SetStateAsync(string? state);
    Task<string?> GetStateAsync();
    Task UpdateDataAsync(string key, object value);
    Task UpdateDataAsync(Dictionary<string, object> data);
    Task SetDataAsync(Dictionary<string, object> data);
    Task<Dictionary<string, object>> GetDataAsync();
    Task ClearAsync();
}
