using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class Euro : Currency
    {
        public override decimal ConversionRate { get; init; } = 7.4394M;
        public override string IsoCurrencyCode { get; init; } = "EUR";
    }
}
