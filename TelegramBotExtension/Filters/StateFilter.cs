using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters
{
    public class StateFilter : FilterAttribute
    {
        public StateFilter(string data) : base(data) { }

        public override bool Call(Context context)
        {
            var state = context.State;
            if (state == null)
                return true;
            return state.GetState() == Data;
        }

    }

}
