using CurrencyConverter.Handlers.Base;
using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers;

public class CurrencyConverterHandler : AbstractHandler, ICurrencyConverterHandler
{
    public override InputContext Handle(InputContext context)
    {
        var originalAmount = context.OriginalAmount;
        var mainCurrencyConversionRate = context.MainCurrency.ConversionRate;
        var moneyCurrencyConversionRate = context.MoneyCurrency.ConversionRate;

        var convertedAmount = originalAmount * mainCurrencyConversionRate / moneyCurrencyConversionRate;

        context.SetConvertedAmount(convertedAmount);

        return context;
    }
}