namespace TelegramBotExtension.FiniteStateMachine
{
    public interface IState
    {
        void SetState(string state);

        string GetState();

        void UpdateData(Dictionary<string, object> data);

        void SetData(Dictionary<string, object> data);

        public Dictionary<string, object> GetData();

        void Clear();

    }

}
