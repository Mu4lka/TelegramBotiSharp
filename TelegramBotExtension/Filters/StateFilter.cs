using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Filters;

public class StateFilter(string state) : FilterAttribute(state)
{
    public override async Task<bool> Call(BaseContext baseContext)
    {
        bool result = false;
        if (baseContext is Context context)
            result = await context.State.GetState() == Data;
        return result;
    }
}
