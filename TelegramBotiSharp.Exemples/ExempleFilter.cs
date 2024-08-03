using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;

namespace TelegramBotiSharp.Exemples;

internal class ExempleFilter(string? data) : FilterAttribute(data)
{
    public override async Task<bool> CallAsync(TelegramContext context)
    {
        //code...
        return true;
    }
}
