using TelegramBotExtension.Types.Base;

namespace TelegramBotExtension.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class FilterAttribute : Attribute
    {
        public string? Data { get; set; }

        public FilterAttribute() { }

        public FilterAttribute(string? data)
        {
            Data = data;
        }

        public abstract Task<bool> Call(Context context);

    }

}
