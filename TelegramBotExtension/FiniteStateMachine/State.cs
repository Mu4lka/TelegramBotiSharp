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

        public void SetState(string? state) => _storage.SetState(_id, state);

        public string? GetState() => _storage.GetState(_id);

        public void UpdateData(string key, object value) => _storage.UpdateData(_id, key, value);

        public void UpdateData(Dictionary<string, object> data) => _storage.UpdateData(_id, data);

        public void SetData(Dictionary<string, object> data) => _storage.SetData(_id, data);

        public Dictionary<string, object> GetData() => _storage.GetData(_id);

        public void Clear() => _storage.Clear(_id);

    }

}
