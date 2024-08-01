using NUnit.Framework;
using Moq;
using TelegramBotExtension.Filters;
using TelegramBotExtension.Types;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBotExtension.Tests.FiltersTests;

[TestFixture]
public class DataFilterTests
{
    private string _data;
    private DataFilter _dataFilter;
    private Mock<ITelegramBotClient> _mockBotClient;
    private TelegramContext _context;

    [SetUp]
    public void SetUp()
    {
        // Arrange
        _data = "testData";
        _dataFilter = new DataFilter(_data);
        _mockBotClient = new Mock<ITelegramBotClient>();
        _context = new TelegramContext(_mockBotClient.Object, new Update(), 1, _data);
    }

    [Test]
    public async Task Call_WhenDataMatches_ReturnsTrue()
    {
        // Act
        var result = await _dataFilter.Call(_context);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Call_WhenDataDoesNotMatch_ReturnsFalse()
    {
        // Arrange
        var differentContext = new TelegramContext(_mockBotClient.Object, new Update(), 1, "differentData");

        // Act
        var result = await _dataFilter.Call(differentContext);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenDataIsNullAndContextDataIsNull_ReturnsTrue()
    {
        // Arrange
        var nullDataFilter = new DataFilter(null);
        var nullDataContext = new TelegramContext(_mockBotClient.Object, new Update(), 1, null);

        // Act
        var result = await nullDataFilter.Call(nullDataContext);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public async Task Call_WhenDataIsNullAndContextDataIsNotNull_ReturnsFalse()
    {
        // Arrange
        var nullDataFilter = new DataFilter(null);
        var notNullDataContext = new TelegramContext(_mockBotClient.Object, new Update(), 1, "notNullData");

        // Act
        var result = await nullDataFilter.Call(notNullDataContext);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task Call_WhenDataIsNotNullAndContextDataIsNull_ReturnsFalse()
    {
        // Arrange
        var notNullDataFilter = new DataFilter("notNullData");
        var nullDataContext = new TelegramContext(_mockBotClient.Object, new Update(), 1, null);

        // Act
        var result = await notNullDataFilter.Call(nullDataContext);

        // Assert
        Assert.That(result, Is.False);
    }
}