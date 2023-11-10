using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class NorwegianKrone : Currency
    {
        public override decimal ConversionRate { get; init; } = 00.7840M;
        public override string IsoCurrencyCode { get; init; } = "NOK";
    }
}
