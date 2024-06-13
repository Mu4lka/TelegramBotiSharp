using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types.Payments;
using TelegramBotExtension.Types.Contexts.Base;

namespace TelegramBotExtension.Types.Contexts;

public class ShippingQueryContext(
    ITelegramBotClient bot,
    CancellationToken cancellationToken,
    ShippingQuery shippingQuery
    ) : Context(bot, cancellationToken, shippingQuery.From.Id, shippingQuery.InvoicePayload)
{
    public ShippingQuery ShippingQuery { get; set; } = shippingQuery;
}
