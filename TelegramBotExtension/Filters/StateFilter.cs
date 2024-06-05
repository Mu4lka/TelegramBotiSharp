using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Filters
{
    public class StateFilter : FilterAttribute
    {
        public StateFilter(string state) : base(state) { }

        public override async Task<bool> Call(Context context)
        {
            var state = await context.State.GetState();
            return state == Data;
        }

    }

}
