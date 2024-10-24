# TelegramBotiSharp

**TelegramBotiSharp** — это библиотека, дополняющая стандартную библиотеку [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) для создания телеграм-ботов на **C#**. Используя эту небольшую библиотеку, вы получите удобные инструменты для разработки более сложных телеграм-ботов.

## Преимущества и дополнения
1. **Нет необходимости проверять тип обновления** — больше не нужно вручную проверять типы обновлений, так как существуют специальные классы-обработчики для каждого типа обновления.
2. **Информация о пользователе теперь в одном месте** — вам не нужно вручную извлекать данные пользователя из обновления, он уже находится в классе `TelegramContext`.
3. **Добавлено хранилище данных пользователя** — теперь можно сохранять состояние и данные пользователя.
4. **Добавлены фильтры** — вы можете создавать обработчики одного типа обновлений для различных сценариев.

## Быстрый старт

### Способы установки
1. Отклонировать репозиторий.
2. Скачать zip-архив репозитория.
3. Использовать NuGet по ссылке: https://gitlab.com/api/v4/projects/60794766/packages/nuget/index.json.

Для использования NuGet, добавьте в проект файл `nuget.config` со следующим содержимым:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="TelegramBotiSharp" value="https://gitlab.com/api/v4/projects/60794766/packages/nuget/index.json" />
  </packageSources>
</configuration>
```

### Пример Program.cs
Заполните файл `Program.cs` следующим кодом:

```C#
// Замените "TOKEN" на реальный токен вашего бота
ITelegramBotClient botClient = new TelegramBotClient("TOKEN");

// Запускаем бота, передав в метод экземпляр класса UpdateHandler с вашими обработчиками
await botClient.StartReceivingAsync(new UpdateHandler([new CommandHandler()]));

// Класс обработчика сообщений с фильтром команды
internal class CommandHandler : MessageHandler
{
    [CommandFilter("start")]
    public override Task HandleAsync(TelegramContext context)
    {
        Console.WriteLine(context.Data);
        return Task.CompletedTask;
    }
}
```

## Краткая документация
### Создание класса обработчика
```C#
internal class StartCommandHandler : MessageHandler
{
    [CommandFilter("start")]
    public override async Task HandleAsync(TelegramContext context)
    {
        await context.BotClient.SendTextMessageAsync(context.UserId, "Hello, World!");
    }
}
```
В этом примере обработчик StartCommandHandler будет срабатывать, когда пользователь отправит команду "/start".

**Основные обработчики:**
* `CallbackQueryHandler` — для обработки `Telegram.Bot.Types.CallbackQuery`;
* `MessageHandler` — для обработки `Telegram.Bot.Types.Message`.

Остальные обработчики можно найти в папке проекта TelegramBotiSharp\Handling\Handlers.

### Фильтры
Пример выше использует фильтр-атрибут `CommandFilter("start")`, который сработает, если пользователь отправит сообщение-команду "/start".

Фильтры можно использовать одновременно для создания более сложной логики:

```C#
internal class ExempleHandler : CallbackQueryHandler
{
    [StateFilter("state_proccess")]
    [DataFilter("Далее")]
    public override async Task HandleAsync(TelegramContext context)
    {
        // Ваш код
    }
}
```
В этом примере обработчик сработает, если состояние пользователя — State.Proccess, и пользователь нажал на кнопку с данными "Далее".

**Основные фильтры**
* `CommandFilter` — сообщение является командой.
* `StateFilter` — состояние пользователя.
* `DataFilter` — данные, отправленные пользователем.

Все фильтры данной библиотеке находятся в пространстве имен `TelegramBotiSharp.Filters`

### Кастомные фильтры

Чтобы создать собственный фильтр, создайте класс, наследующий от `FilterAttribute`, и реализуйте его:

```C#
internal class ExempleFilter(string? data) : FilterAttribute
{
    public override async Task<bool> CallAsync(TelegramContext context)
    {
        // Ваш код
    }
}
```

### Параллельное выполенение обработчиков

Данная библиотека предоставляет новый тип данных `ParallelUpdateReceiver`, определенный в пространстве имен `TelegramBotiSharp.Handling.Polling`.
Данный тип обрабатывает обновления `Telegram.Bot.Types.Update` параллельно, а не последовательно, тем самым увеличивается скорость обработки.

Недостатком является то, что обработка становится недетерминированной, и в некоторых случаях это может приводить к разному порядку вывода сообщений.

#### Использование

Всё очень просто! Передайте в метод `StartReceivingAsync` экземпляр класса `ParallelUpdateReceiver`, как показано в следующем примере:

```C#
await botClient.StartReceivingAsync(updateHandler, new ParallelUpdateReceiver(botClient));
```