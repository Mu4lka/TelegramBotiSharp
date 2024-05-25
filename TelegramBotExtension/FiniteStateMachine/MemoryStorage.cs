namespace TelegramBotExtension.FiniteStateMachine
{
    public class MemoryStorage : IStorage
    {
        public static Dictionary<long, string> States = [];
        public static Dictionary<long, Dictionary<string, object>> Data = [];

        public void SetState(long id, string state)
        {
            States[id] = state;
        }

        public string GetState(long id)
        {
            if (!States.ContainsKey(id))
                SetState(id, null);
            return States[id];
        }

        public void UpdateData(long id, Dictionary<string, object> data)
        {
            if (!Data.ContainsKey(id))
                Data[id] = [];
            foreach (var kvp in data)
                Data[id].Add(kvp.Key, kvp.Value);
        }

        public void SetData(long id, Dictionary<string, object> data)
        {
            Data[id] = data;
        }

        public Dictionary<string, object> GetData(long id)
        {
            if (!Data.ContainsKey(id))
                SetData(id, []);
            return Data[id];
        }

        public void Clear(long id)
        {
            States.Remove(id);
            Data.Remove(id);
        }

    }

}