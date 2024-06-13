using Moq;
using Telegram.Bot;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Tests.FiltersTests;

public class TestContext : Context
{
    public TestContext(
        ITelegramBotClient bot,
        CancellationToken cancellationToken,
        long id,
        string data) : base(bot, cancellationToken, id, data) { }
}

[TestFixture]
public class DataFilterTests
{
    private string _data;
    private TestContext _context;
    private Mock<ITelegramBotClient> _mockBotClient;

    [SetUp]
    public void Setup()
    {
        _data = "data";
        _mockBotClient = new Mock<ITelegramBotClient>();
        _context = new TestContext(_mockBotClient.Object, CancellationToken.None, 1, _data);
    }

    [Test]
    public async Task Call_WhenDataMatches_ReturnsTrue()
    {
        // Arrange
        var dataFilter = new DataFilter(_data);

        // Act
        var result = await dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Call_WhenDataDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        _context.Data = "different";
        var dataFilter = new DataFilter(_data);

        // Act
        var result = await dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenContextDataIsNull_ReturnsFalse()
    {
        // Arrange
        _context.Data = null!;
        var dataFilter = new DataFilter(_data);

        // Act
        var result = await dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenFilterDataIsNull_ReturnsFalse()
    {
        // Arrange
        var dataFilter = new DataFilter(null!);

        // Act
        var result = await dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenBothDataAreNull_ReturnsTrue()
    {
        // Arrange
        _context.Data = null!;
        var dataFilter = new DataFilter(null!);

        // Act
        var result = await dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.True);
    }
}
