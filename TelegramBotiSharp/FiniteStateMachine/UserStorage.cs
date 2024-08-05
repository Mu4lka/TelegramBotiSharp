namespace TelegramBotExtension.FiniteStateMachine;

public class UserStorage(long id, IStorage _storage) : IUserStorage
{
    private readonly long _id = id;

    public Task SetState(string? state) => _storage.SetState(_id, state);

    public Task<string?> GetState() => _storage.GetState(_id);

    public Task UpdateData(string key, object value) => _storage.UpdateData(_id, key, value);

    public Task UpdateData(Dictionary<string, object> data) => _storage.UpdateData(_id, data);

    public Task SetData(Dictionary<string, object> data) => _storage.SetData(_id, data);

    public Task<Dictionary<string, object>> GetData() => _storage.GetData(_id);

    public Task Clear() => _storage.Clear(_id);
}
