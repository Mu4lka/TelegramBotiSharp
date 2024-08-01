# TelegramBotiSharp

**TelegramBotiSharp**- абстакция над библиотекой [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) на **.NET 8.0**.
Использовав данную небольшую библиотеку, она обеспечит вам удобство написания более сложных телеграм-ботов на **C#**

## Преимущество
1. Не надо проверять тип обновления - Вам больше не нужно проверять конкретные типы обновления, так как существуют классы-обработчики конкретного типа обновления
2. Айди пользователя теперь в одном месте - Вам больше не нужно получать Айди пользователя из типа обновления, теперь он находится в классе TelegramContext
3. Машина состояния - Вы сможете сохранять состояние пользователя и обрабатывать его
4. Кастомизация - Вы сможете самостоятельно делать свои фильтры
   
## Быстрый старт
Клонируйте данный репозиторий
Токен поместите в appsettings.json
Запустите

## Краткая документация
* Создание класса обработчика
```C#
internal class StartCommandHandler : MessageHandler
{
    [CommandFilter("start")]
    public override async Task HandleUpdateAsync(TelegramContext context)
    {
        await context.BotClient.SendTextMessageAsync(context.UserId, "Hello, World!");
    }
}
```

