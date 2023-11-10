using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class SwedishKrona : Currency
    {
        public override decimal ConversionRate { get; init; } = 0.7610M;
        public override string IsoCurrencyCode { get; init; } = "SEK";
    }
}
