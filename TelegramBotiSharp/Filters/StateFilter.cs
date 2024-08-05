using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters;

public class StateFilter(string? state) : FilterAttribute(state)
{
    public override async Task<bool> CallAsync(TelegramContext context)
        => await context.UserStorage.GetStateAsync() == Data;
}
