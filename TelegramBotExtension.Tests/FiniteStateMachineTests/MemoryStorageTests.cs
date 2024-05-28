using System.Collections.Concurrent;
using TelegramBotExtension.FiniteStateMachine;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TelegramBotExtension.Tests.FiniteStateMachineTests
{
    public class MemoryStorageTests
    {
        private ConcurrentDictionary<long, string?> _states;
        private ConcurrentDictionary<long, ConcurrentDictionary<string, object>> _data;
        private IStorage _storage;

        [SetUp]
        public void Setup()
        {
            _states = [];
            _data = [];
            _storage = new MemoryStorage();
        }

        [TestCase(1, null)]
        public void GetState_NotIdInStorage_(long id, string? expected)
        {
            var storage = new MemoryStorage();

            var actual = storage.GetState(id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, null)]
        [TestCase(1, "state")]
        [TestCase(2, null)]
        public void GetStateTestWhenIdIsInStorage(long id, string? expected)
        {
            var states = new ConcurrentDictionary<long, string?>(
                new Dictionary<long, string?>() { { id, expected }, }
                );
            var storage = new MemoryStorage(states, _data);

            var actual = storage.GetState(id);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, null)]
        [TestCase(1, "state")]
        public void SetStateTestIdIsNotInStorage(long id, string? expected)
        {

        }



        //[Test]
        //public void UpdateDataTest(long id, string key, object value)
        //{

        //}


        //[Test]
        //public void UpdateDataTest(long id, Dictionary<string, object> data)
        //{

        //}


        //[Test]
        //public void SetDataTest(long id, Dictionary<string, object> data)
        //{

        //}

        //[Test]
        //public void GetDataTest(long id)
        //{

        //}

        //[Test]
        //public void ClearTest(long id)
        //{

        //}

    }
}