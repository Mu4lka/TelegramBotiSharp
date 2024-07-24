using Moq;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;
using Telegram.Bot;

namespace TelegramBotExtension.Tests.FiltersTests;

[TestFixture]
public class CommandFilterTests
{
    private Message _message;
    private string _commandText;
    private CommandFilter _commandFilter;
    private Mock<ITelegramBotClient> _mockBotClient;
    private TelegramContext _context;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        _commandText = "test";
        _commandFilter = new CommandFilter(_commandText);
        _mockBotClient = new Mock<ITelegramBotClient>();
        _message = new Message
        {
            Text = "/" + _commandText,
            Entities = [new MessageEntity { Type = MessageEntityType.BotCommand }],
            From = new User { Id = 1 }
        };
        _context = new TelegramContext(_mockBotClient.Object, new Update { Message = _message }, 1, string.Empty);
    }

    [Test]
    public async Task Call_WhenCommandMatches_ReturnsTrue()
    {
        // Act
        var result = await _commandFilter.Call(_context);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Call_WhenCommandDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        _message.Text = "/wrong";
        _context = new TelegramContext(_mockBotClient.Object, new Update { Message = _message }, 1, string.Empty);

        // Act
        var result = await _commandFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenNullEntities_ReturnsFalse()
    {
        // Arrange
        _message.Entities = null;
        _context = new TelegramContext(_mockBotClient.Object, new Update { Message = _message }, 1, string.Empty);

        // Act
        var result = await _commandFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenEntityTypeDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        _message.Entities = [ new MessageEntity { Type = MessageEntityType.Cashtag } ];
        _context = new TelegramContext(_mockBotClient.Object, new Update { Message = _message }, 1, string.Empty);

        // Act
        var result = await _commandFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenNullMessage_ReturnsFalse()
    {
        // Arrange
        var nullMessageUpdate = new Update { Message = null };
        _context = new TelegramContext(_mockBotClient.Object, nullMessageUpdate, 1, string.Empty);

        // Act
        var result = await _commandFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }
}