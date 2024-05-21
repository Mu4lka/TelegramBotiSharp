using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotExtension.Types;

namespace TelegramBotExtension.Filters
{
    internal class DataFilter : FilterAttribute
    {
        public DataFilter(string data) : base(data)
        {
        }

        public override bool Call(Context context)
        {
            return Data == context.
        }
    }
}
