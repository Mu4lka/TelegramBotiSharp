using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TelegramBotExtension.Handling;
using TelegramBotExtension.Exemples.ConsoleApp;
using TelegramBotExtension.FiniteStateMachine;

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((hostContext, services) =>
    {
        var token = hostContext.Configuration.GetValue<string>("BotSettings:Token")!;

        services.AddSingleton<ITelegramBotClient, TelegramBotClient>(x => new TelegramBotClient(
                token: token));
        services
            .AddSingleton<UpdateHandler>()
            .AddTransient<IStorage, MemoryStorage>()
            .AddTransient<IUpdateTypeHandler, StartCommandHandler>();

        var updateHandler = services
            .BuildServiceProvider()
            .GetRequiredService<UpdateHandler>();

        updateHandler.StartBot();
    });

builder.ConfigureAppConfiguration(conf =>
{
    conf.AddJsonFile("appsettings.json", optional: false, true)
        .AddUserSecrets(Assembly.GetCallingAssembly(), true)
        .AddEnvironmentVariables();
});

var app = builder.Build();

await app.RunAsync();