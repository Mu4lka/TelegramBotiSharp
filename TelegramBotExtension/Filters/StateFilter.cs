using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Filters
{
    public class StateFilter : FilterAttribute
    {
        public StateFilter(string state) : base(state) { }

        public override Task<bool> Call(Context context)
        {
            return Task.FromResult(context.State.GetState() == Data);
        }

    }

}
