# TelegramBotiSharp

**TelegramBotiSharp**- абстакция над библиотекой [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) на **.NET 8.0**.
Использовав данную небольшую библиотеку, она обеспечит вам удобство написания более сложных телеграм-ботов на **C#**

## Преимущество
1. Не надо проверять тип обновления - Вам больше не нужно проверять конкретные типы обновления, так как существуют классы-обработчики конкретного типа обновления
2. Айди пользователя теперь в одном месте - Вам больше не нужно получать Айди пользователя из типа обновления, теперь он находится в классе TelegramContext
3. Машина состояния - Вы сможете сохранять состояние пользователя и обрабатывать его
4. Кастомизация - Вы сможете самостоятельно делать свои фильтры
   
## Быстрый старт
1. Клонируйте данный репозиторий
2. Токен поместите в appsettings.json
3. Запустите

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
В данном примере обработчик StartCommandHandler будет обрабатываться а том случае, если пользователь отправил сообщение

**Основные обработчки:**
* CallbackQueryHandler - триггер на Telegram.Bot.Types.CallbackQuery
* MessageHandler - триггер на Telegram.Bot.Types.Message

* Фильтры
В примере выше был использован фильтр-aттрибут CommandFilter("start"), обработчик сработает в том случае если пользователь отправит сообщение-команду "/start"
