using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.CurrencyProviders;

public class BritishPound : Currency
{
    public override decimal ConversionRate { get; init; } = 8.5285M;
    public override string IsoCurrencyCode { get; init; } = "GBP";
}