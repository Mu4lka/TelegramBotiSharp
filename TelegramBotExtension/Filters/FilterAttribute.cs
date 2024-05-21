using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class FilterAttribute : Attribute
    {
        public string? Data;

        public FilterAttribute(string? data)
        {
            Data = data;
        }

        public abstract bool Call(Context context);

    }

}
