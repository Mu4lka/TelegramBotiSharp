using Telegram.Bot.Types.Enums;

namespace TelegramBotiSharp.Handling.Polling;

/// <summary>
/// Options to configure getUpdates requests
/// </summary>
public sealed class ReceiverOptions
{
    private int _limit;

    /// <summary>
    /// Identifier of the first update to be returned. Will be ignored if
    /// <see cref="DropPendingUpdates"/> is set to <see langword="true"/>.
    /// </summary>
    public int Offset { get; set; }

    /// <summary>
    /// Indicates which <see cref="UpdateType"/>s are allowed to be received.
    /// In case of <see langword="null"/> the previous setting will be used
    /// </summary>
    public UpdateType[]? AllowedUpdates { get; set; }

    /// <summary>
    /// Limits the number of updates to be retrieved. Values between 1-100 are accepted.
    /// Defaults to 100 when is set to <see langword="null"/>.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the value doesn't satisfies constraints
    /// </exception>
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

    /// <summary>
    /// Indicates if all pending <see cref="Update"/>s should be thrown out before start
    /// polling. If set to <see langword="true"/> <see cref="AllowedUpdates"/> should be set to not
    /// <see langword="null"/>, otherwise <see cref="AllowedUpdates"/> will effectively be set to
    /// receive all <see cref="Update"/>s.
    /// </summary>
    public bool DropPendingUpdates { get; set; }

    /// <summary>
    /// Returns default receiver оptions
    /// </summary>
    public static ReceiverOptions Default()
        => new() { Limit = 100, Offset = 0 };
}