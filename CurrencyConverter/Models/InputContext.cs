using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.Models;

public class InputContext
{
    public string UserInput { get; init; }
    public Currency MainCurrency { get; protected set; }
    public Currency MoneyCurrency { get; protected set; }
    public decimal OriginalAmount { get; protected set; }
    public decimal ConvertedAmount { get; protected set; }

    public void SetMainCurrency(Currency currency)
    {
        MainCurrency = currency;
    }

    public void SetMoneyCurrency(Currency currency)
    {
        MoneyCurrency = currency;
    }

    public void SetOriginalAmount(decimal amount)
    {
        OriginalAmount = amount;
    }

    public void SetConvertedAmount(decimal amount)
    {
        ConvertedAmount = amount;
    }
}