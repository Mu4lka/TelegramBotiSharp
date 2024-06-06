using System.Collections.Concurrent;

namespace TelegramBotExtension.FiniteStateMachine
{
    public class MemoryStorage : IStorage
    {
        private readonly ConcurrentDictionary<long, string?> _states;
        private readonly ConcurrentDictionary<long, ConcurrentDictionary<string, object>> _data;

        public MemoryStorage()
        {
            _states = new ConcurrentDictionary<long, string?>();
            _data = new ConcurrentDictionary<long, ConcurrentDictionary<string, object>>();
        }

        public Task SetState(long id, string? state)
        {
            _states[id] = state;
            return Task.CompletedTask;
        }

        public Task<string?> GetState(long id)
        {
            _states.TryGetValue(id, out var state);
            return Task.FromResult(state);
        }

        public async Task UpdateData(long id, string key, object value)
        {
            await Task.Run(() =>
            {
                _data.AddOrUpdate(
                    id,
                    new ConcurrentDictionary<string, object>(new[] { new KeyValuePair<string, object>(key, value) }),
                    (existingId, existingData) =>
                    {
                        existingData[key] = value;
                        return existingData;
                    });
            });
        }

        public async Task UpdateData(long id, Dictionary<string, object> data)
        {
            foreach (var item in data)
            {
                await UpdateData(id, item.Key, item.Value);
            }
        }

        public Task SetData(long id, Dictionary<string, object> data)
        {
            _data[id] = new ConcurrentDictionary<string, object>(data);
            return Task.CompletedTask;
        }

        public Task<Dictionary<string, object>> GetData(long id)
        {
            if (_data.TryGetValue(id, out var data))
            {
                return Task.FromResult(new Dictionary<string, object>(data));
            }
            else
            {
                return Task.FromResult(new Dictionary<string, object>());
            }
        }

        public Task Clear(long id)
        {
            _states.TryRemove(id, out var _);
            _data.TryRemove(id, out var _);
            return Task.CompletedTask;
        }

    }

}
