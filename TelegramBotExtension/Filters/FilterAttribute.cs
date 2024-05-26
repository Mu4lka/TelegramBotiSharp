using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
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
