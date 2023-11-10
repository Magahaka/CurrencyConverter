using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders
{
    public class UnitedStatesDollar : Currency
    {
        public override decimal ConversionRate { get; init; } = 6.6311M;
        public override string IsoCurrencyCode { get; init; } = "USD";
    }
}
