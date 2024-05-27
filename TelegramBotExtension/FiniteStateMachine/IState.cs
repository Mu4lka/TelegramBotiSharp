namespace TelegramBotExtension.FiniteStateMachine
{
    internal interface IState
    {
        void SetState(string state);

        string GetState();

        void UpdateData((string, object) data);

        void UpdateData((string, object)[] data);

        void SetData(Dictionary<string, object> data);

        public Dictionary<string, object> GetData();

        void Clear();

    }

}
