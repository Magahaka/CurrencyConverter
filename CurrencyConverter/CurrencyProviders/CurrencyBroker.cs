using CurrencyConverter.CurrencyProviders.Base;
using CurrencyConverter.Interfaces.Broker;
using CurrencyConverter.Utils;
using System.Reflection;

namespace CurrencyConverter.CurrencyProviders;


public class CurrencyBroker : ICurrencyBroker
{
    private readonly IDictionary<string, Currency> _currencies;

    public CurrencyBroker()
    {
        var currencyType = typeof(Currency);
        var assembly = Assembly.GetExecutingAssembly();

        _currencies = assembly.GetTypes()
            .Where(x => x.IsSubclassOf(currencyType))
            .Select(x =>
            {
                var parameterlessConstructor = x.GetConstructors()
                    .SingleOrDefault(c => c.GetParameters().Length == 0);

                return Activator.CreateInstance(x);
            })
            .Cast<Currency>()
            .ToDictionary(x => x.IsoCurrencyCode, x => x);
    }

    public Currency GetCurrencyByIsoCode(string isoCode)
    {
        if (!_currencies.TryGetValue(isoCode, out var currency))
        {
            throw new KeyNotFoundException(
                Constants.IncorrectExchangeCommandResponse(
                    $"Currency with ISO code {isoCode} not found"));
        }

        return currency;
    }
}