using CurrencyConverter.CurrencyProviders.Base;

namespace CurrencyConverter.Interfaces.Broker;

public interface ICurrencyBroker
{
    Currency GetCurrencyByIsoCode(string isoCode);
}