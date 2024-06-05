namespace TelegramBotExtension.FiniteStateMachine
{
    public class State: IState
    {
        private static IStorage _storage = new MemoryStorage();

        private readonly long _id;

        public State(long id)
        {
            _id = id;
        }

        public async Task SetState(string? state) => await _storage.SetState(_id, state);

        public async Task<string?> GetState() => await _storage.GetState(_id);

        public async Task UpdateData(string key, object value) => await _storage.UpdateData(_id, key, value);

        public async Task UpdateData(Dictionary<string, object> data) => await _storage.UpdateData(_id, data);

        public async Task SetData(Dictionary<string, object> data) => await _storage.SetData(_id, data);

        public async Task<Dictionary<string, object>> GetData() => await _storage.GetData(_id);

        public async Task Clear() => await _storage.Clear(_id);

    }

}
