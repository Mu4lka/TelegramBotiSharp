using TelegramBotExtension.FiniteStateMachine;

namespace TelegramBotExtension.Tests.FSMTests
{
    [TestFixture]
    public class MemoryStorageTests
    {
        private IStorage _storage;
        private long _id;

        [SetUp]
        public void Setup()
        {
            //Arrange
            _storage = new MemoryStorage();
            _id = 1;
        }

        [Test]
        public async Task SetState_ShouldStoreState()
        {
            //Arrange
            string state = "state";

            //Act
            await _storage.SetState(_id, state);
            string? storedState = await _storage.GetState(_id);

            //Assert
            Assert.IsNotNull(storedState);
            Assert.AreEqual(state, storedState);
        }

        [Test]
        public async Task GetState_ShouldReternNullIfStateNotSet()
        {
            //Act
            string? storedState = await _storage.GetState(_id);

            //Assert
            Assert.IsNull(storedState);
        }

        [Test]
        public async Task UpdateData_ShouldStoreData()
        {
            //Arrange
            string key = "key";
            string value = "value";

            //Act
            await _storage.UpdateData(_id, key, value);
            var storedData = await _storage.GetData(_id);

            //Assert
            Assert.IsTrue(storedData.ContainsKey(key));
            Assert.AreEqual(value, storedData[key]);
        }

        [Test]
        public async Task UpdateData_MultipleUpdates_ShouldStoreAllData()
        {
            //Arrange
            var data = new Dictionary<string, object>
            {
                {"key", "value"},
                {"key2", 2 },
                { "key3", new object[] { } }
            };

            //Act
            await _storage.UpdateData(_id, data);
            var storedData = await _storage.GetData(_id);

            //Assert
            foreach (var kvp in storedData)
            {
                Assert.IsTrue(storedData.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, data[kvp.Key]);
            }
        }

        [Test]
        public async Task SetData_ShouldOwerwriteData()
        {
            //Arrange
            var oldData = new Dictionary<string, object>
            {
                {"key", "value"},
            };
            await _storage.UpdateData(_id, oldData);
            var newData = new Dictionary<string, object>
            {
                {"key", "value"},
                {"key2", 2 },
                { "key3", new object[] { } }
            };

            //Act
            await _storage.SetData(_id, newData);
            var storedData = await _storage.GetData(_id);

            //Assert
            foreach (var kvp in storedData)
            {
                Assert.IsTrue(storedData.ContainsKey(kvp.Key));
                Assert.AreEqual(kvp.Value, newData[kvp.Key]);
            }
        }

        [Test]
        public async Task Clear_ShouldRemoveStateAndData()
        {
            //Arrange
            string state = "TestState";
            var data = new Dictionary<string, object>
            {
                { "key", "value" }
            };
            await _storage.SetState(_id, state);
            await _storage.SetData(_id, data);

            //Act
            await _storage.Clear(_id);
            var storedState = await _storage.GetState(_id);
            var storedData = await _storage.GetData(_id);

            //Assert
            Assert.IsNull(storedState);
            Assert.IsEmpty(storedData);
        }

    }

}
