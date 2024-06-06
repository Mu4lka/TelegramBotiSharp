namespace TelegramBotExtension.FiniteStateMachine
{
    public class State: IState
    {
        public static IStorage Storage = new MemoryStorage();

        private readonly long _id;

        public State(long id)
        {
            _id = id;
        }

        public async Task SetState(string? state) => await Storage.SetState(_id, state);

        public async Task<string?> GetState() => await Storage.GetState(_id);

        public async Task UpdateData(string key, object value) => await Storage.UpdateData(_id, key, value);

        public async Task UpdateData(Dictionary<string, object> data) => await Storage.UpdateData(_id, data);

        public async Task SetData(Dictionary<string, object> data) => await Storage.SetData(_id, data);

        public async Task<Dictionary<string, object>> GetData() => await Storage.GetData(_id);

        public async Task Clear() => await Storage.Clear(_id);

    }

}
