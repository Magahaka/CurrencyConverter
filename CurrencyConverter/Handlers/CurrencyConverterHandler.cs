using CurrencyConverter.Handlers.Base;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers;

public class CurrencyConverterHandler : AbstractHandler
{
    public override InputContext Handle(InputContext context)
    {
        var originalAmount = context.OriginalAmount;
        var mainCurrencyConversionRate = context.MainCurrency.ConversionRate;
        var moneyCurrencyConversionRate = context.MoneyCurrency.ConversionRate;

        ThrowExceptionIfMoneyCurrencyConversionRateIsZero(moneyCurrencyConversionRate);

        var convertedAmount = originalAmount * mainCurrencyConversionRate / moneyCurrencyConversionRate;

        context.SetConvertedAmount(convertedAmount);

        return context;
    }

    private static void ThrowExceptionIfMoneyCurrencyConversionRateIsZero(decimal moneyCurrencyConversionRate)
    {
        if (moneyCurrencyConversionRate == decimal.Zero)
        {
            throw new DivideByZeroException("The conversion rate of the money currency cannot be zero.");
        }
    }
}