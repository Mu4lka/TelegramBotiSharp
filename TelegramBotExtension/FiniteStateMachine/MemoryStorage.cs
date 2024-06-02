using System.Collections.Concurrent;

namespace TelegramBotExtension.FiniteStateMachine
{
    public class MemoryStorage : IStorage
    {
        private readonly ConcurrentDictionary<long, string?> _states;
        private readonly ConcurrentDictionary<long, ConcurrentDictionary<string, object>> _data;

        public MemoryStorage()
        {
            _states = new();
            _data = new();
        }

        public MemoryStorage(
            ConcurrentDictionary<long, string?> states,
            ConcurrentDictionary<long, ConcurrentDictionary<string, object>> data
            )
        {
            _states = states;
            _data = data;
        }

        public void SetState(long id, string? state)
        {
            _states[id] = state;
        }

        public string? GetState(long id)
        {
            return _states.GetOrAdd(id, _ => null);
        }

        public void UpdateData(long id, string key, object value)
        {
            _data.AddOrUpdate(
                id,
                new ConcurrentDictionary<string, object>(new[]{ new KeyValuePair<string, object>(key, value) }),
                (existingId, existingData) =>
                {
                    existingData[key] = value;
                    return existingData;
                });
        }

        public void UpdateData(long id, Dictionary<string, object> data)
        {
            foreach (var item in data)
                UpdateData(id, item.Key, item.Value);
        }

        public void SetData(long id, Dictionary<string, object> data)
        {
            _data[id] = new ConcurrentDictionary<string, object>(data);
        }

        public Dictionary<string, object> GetData(long id)
        {
            return _data.TryGetValue(id, out var data) ? new Dictionary<string, object>(data) : new();
        }

        public void Clear(long id)
        {
            _states.TryRemove(id, out _);
            _data.TryRemove(id, out _);
        }

    }

}
