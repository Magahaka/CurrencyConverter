using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class JapaneseYen : Currency
    {
        public override decimal ConversionRate { get; init; } = 00.59740M;
        public override string IsoCurrencyCode { get; init; } = "JPY";
    }
}
