using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;
using Moq;
using Telegram.Bot;

namespace TelegramBotExtension.Tests.FiltersTests;

[TestFixture]
public class CommandTests
{
    private Message _message;
    private string _commandText;
    private Command _command;
    private Mock<ITelegramBotClient> _mockBotClient;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        _commandText = "test";
        _command = new Command(_commandText);
        _mockBotClient = new Mock<ITelegramBotClient>();
        _message = new Message
        {
            Text = "/" + _commandText,
            Entities = new[]
            {
                new MessageEntity { Type = MessageEntityType.BotCommand }
            },
            From = new User { Id = 1 }
        };
    }

    [Test]
    public async Task Call_WhenCommandMatches_ReturnsTrue()
    {
        // Arrange
        var context = new MessageContext(_mockBotClient.Object, CancellationToken.None, _message);

        // Act
        var result = await _command.Call(context);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task Call_WhenCommandDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        _message.Text = "/wrong";
        var context = new MessageContext(_mockBotClient.Object, CancellationToken.None, _message);

        // Act
        var result = await _command.Call(context);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task Call_WhenNullEntities_ReturnsFalse()
    {
        // Arrange
        _message.Entities = null;
        var context = new MessageContext(_mockBotClient.Object, CancellationToken.None, _message);

        // Act
        var result = await _command.Call(context);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task Call_WhenEntityTypeDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        _message.Entities = new[] { new MessageEntity { Type = MessageEntityType.Cashtag } };
        var context = new MessageContext(_mockBotClient.Object, CancellationToken.None, _message);

        // Act
        var result = await _command.Call(context);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task Call_WhenNullMessage_ReturnsFalse()
    {
        // Arrange
        var nullMessage = new Message { From = new User { Id = 123456789 } }; // Ensure User is not null
        var context = new MessageContext(_mockBotClient.Object, CancellationToken.None, nullMessage);

        // Act
        var result = await _command.Call(context);

        // Assert
        Assert.IsFalse(result);
    }
}