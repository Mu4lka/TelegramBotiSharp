using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters
{
    public class DataFilter : FilterAttribute
    {
        public DataFilter(string data) : base(data) { }

        public override Task<bool> Call(Context context)
        {
            return Task.FromResult(Data == context.Data);
        }

    }

}
