using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Filters;

public class StateFilter(string state) : FilterAttribute(state)
{
    public override async Task<bool> Call(Context context)
        => await context.State.GetState() == Data;
}
