# TelegramBotiSharp

**TelegramBotiSharp** - это библиотека, дополняющая стандратную библиотеку [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot) по созданию телеграм-ботов на **C#**.
Использовав данную небольшую библиотеку, она обеспечит вам удобство написания более сложных телеграм-ботов.

## Преимущество и дополнения
1. Не надо проверять тип обновления - Вам больше не нужно проверять конкретные типы обновления, так как существуют классы-обработчики конкретного типа обновления;
2. Пользователь теперь в одном месте - Вам больше не нужно получать Айди пользователя из типа обновления, теперь он находится в классе TelegramContext;
3. Добавлено хранилище для пользователя - Вы сможете сохранять состояние пользователя и сохранять его данные;
4. Добавлены фильтры - Вы можете делать обраюотчики одного типа обновления для разных сценариев;


## Быстрый старт
### Варианты скачивания
1. Отклонировать репозиторий
2. Скачать zip репозитория
3. Nuget доступный по ссылке https://gitlab.com/api/v4/projects/60794766/packages/nuget/index.json

Вы можете в свой проект добавить файл c названием nuget.config со следующим содержимым:

```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="TelegramBotiSharp" value="https://gitlab.com/api/v4/projects/60794766/packages/nuget/index.json" />
  </packageSources>
</configuration>
```

### Файл Program.cs
Заполните файл Program.cs следующим кодом:

```C#
// Созданание экземпляра TelegramBotClient и передаем в конструктор токен бота
ITelegramBotClient botClient = new TelegramBotClient("TOKEN");

// Запускаем бота, передав в параметр метода экземляр класс UpdateHandler(уже реализован от IUpdateHandler) с нашими обработчиками
await botClient.StartReceivingAsync(new UpdateHandler([new CommandHandler()]));

//Класс обработчки новых сообщений, с фильтром на команду
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
В данном примере обработчик StartCommandHandler будет обрабатываться а том случае, если пользователь отправил сообщение-команду "/start"

**Основные обработчки:**
* CallbackQueryHandler - триггер на Telegram.Bot.Types.CallbackQuery
* MessageHandler - триггер на Telegram.Bot.Types.Message

Есть другие обработчики с которыми вы можете ознакомится в папке проекта TelegramBotiSharp\Handling\Handlers

### Фильтры
В примере выше был использован фильтр-aттрибут CommandFilter("start"), обработчик сработает в том случае если пользователь отправит сообщение-команду "/start"

**Основные фильтры:**
* CommandFilter - Cообщение является командой
* StateFilter - Состояние пользователя
* DataFilter - Данные отправленные пользователем

Фильтры могут комбинироваться

```C#
internal class ExempleHandler : CallbackQueryHandler
{
    [StateFilter(nameof(State.Proccess))]
    [DataFilter("Далее")]
    public override async Task HandleUpdateAsync(TelegramContext context)
    {
        //code...
    }
}
```
В примере выше, данный обработчик сработает в том случае, если состояние пользователя будет State.Proccess и он нажал на кнопку InlineKeyboardButton в которой содержится данные "Далее"

### Кастомные фильтры

Чтобы сделать кастомный фильтр, создайте класс, наследованный от FilterAttribute, и реализуйте его. Пример кастомного фильттра:

```C#
internal class ExempleFilter(string? data) : FilterAttribute(data)
{
    public override async Task<bool> CallAsync(TelegramContext context)
    {
        //code...
    }
}
```
