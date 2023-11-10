using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class DanishKrone : Currency
    {
        public override decimal ConversionRate { get; init; } = 1M;
        public override string IsoCurrencyCode { get; init; } = "DKK";
    }
}
