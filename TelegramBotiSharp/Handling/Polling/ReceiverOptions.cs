using Telegram.Bot.Types.Enums;

namespace TelegramBotiSharp.Handling.Polling;

public sealed class ReceiverOptions
{
    private int _limit = 100;

    public int Offset { get; set; } = 0;

    public UpdateType[]? AllowedUpdates { get; set; }

    public int Limit
    {
        get => _limit;
        set
        {
            if (value is < 1 or > 100)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: nameof(value),
                    actualValue: value,
                    message: $"'{nameof(Limit)}' can not be less than 1 or greater than 100"
                );
            }
            _limit = value;
        }
    }
}