using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBotiSharp.Storages;

namespace TelegramBotiSharp.Types;

/// <summary>
/// Builder for creating <see cref="TelegramContext"/>
/// </summary>
public class TelegramContextBuilder
{
    private TelegramContext _context;
    private IUsersStorage<long> _storage;

    private TelegramContextBuilder(TelegramContext context, IUsersStorage<long> storage)
    {
        _context = context;
        _storage = storage;
    }

    public static TelegramContextBuilder Create(
        ITelegramBotClient botClient,
        Update update,
        IUsersStorage<long> storage,
        CancellationToken token = default!)
    {
        var context = new TelegramContext()
        {
            BotClient = botClient,
            Update = update,
            Token = token
        };

        return new TelegramContextBuilder(context, storage);
    }

    public TelegramContext Build()
        => _context;

    public TelegramContextBuilder WithUserStorageItem(Func<Update, long> selector)
    {
        _context.UserStorage = new(selector(_context.Update), _storage);
        return this;
    }

    public TelegramContextBuilder WithUser(Func<Update, User?> selector)
    {
        _context.User = selector(_context.Update);
        return this;
    }

    public TelegramContextBuilder WithData(Func<Update, string?> selector)
    {
        _context.Data = selector(_context.Update);
        return this;
    }
}
