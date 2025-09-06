namespace CurrencyConverter.CurrencyProviders.Base;

public abstract class Currency
{
    public abstract decimal ConversionRate { get; init; }
    public abstract string IsoCurrencyCode { get; init; }
}