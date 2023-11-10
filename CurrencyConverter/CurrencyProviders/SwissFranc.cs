using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class SwissFranc : Currency
    {
        public override decimal ConversionRate { get; init; } = 6.8358M;
        public override string IsoCurrencyCode { get; init; } = "CHF";
    }
}
