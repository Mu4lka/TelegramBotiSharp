namespace TelegramBotExtension.FiniteStateMachine
{
    public interface IStorage
    {
        void SetState(long id, string? state);

        string? GetState(long id);

        void UpdateData(long id, string key, object value);

        void UpdateData(long id, Dictionary<string, object> data);

        void SetData(long id, Dictionary<string, object> data);

        Dictionary<string, object> GetData(long id);

        void Clear(long id);

    }

}
