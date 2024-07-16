using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Exemples.ConsoleApp;
using Telegram.Bot.Polling;
using TelegramBotExtension.FiniteStateMachine;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        var token = hostContext.Configuration.GetValue<string>("BotSettings:Token")!;

        services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(
                token: token));
        services
            .AddSingleton<BotService>()
            .AddTransient<IStorage, MemoryStorage>()
            .AddTransient<IUpdateTypeHandler, StartCommandHandler>();

        var botService = services
            .BuildServiceProvider()
            .GetRequiredService<BotService>();

        botService.StartBot();
    });

builder.ConfigureAppConfiguration(conf =>
{
    conf.AddJsonFile("appsettings.json", optional: false, true)
        .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
        .AddEnvironmentVariables();
});

var app = builder.Build();

await app.RunAsync();
