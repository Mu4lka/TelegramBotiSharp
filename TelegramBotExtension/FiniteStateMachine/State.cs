namespace TelegramBotExtension.FiniteStateMachine
{
    public class State: IState
    {
        static public IStorage Storage = new MemoryStorage();

        private readonly long _id;

        public State(long id)
        {
            _id = id;
        }

        public void SetState(string state) => Storage.SetState(_id, state);

        public string GetState() => Storage.GetState(_id);

        public void UpdateData(Dictionary<string, object> data) => Storage.UpdateData(_id, data);

        public void SetData(Dictionary<string, object> data) => Storage.SetData(_id, data);

        public Dictionary<string, object> GetData() => Storage.GetData(_id);

        public void Clear() => Storage.Clear(_id);

    }

}