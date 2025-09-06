using CurrencyConverter.Interfaces.Broker;
using CurrencyConverter.Interfaces.Services;
using CurrencyConverter.Validators;

namespace CurrencyConverter.Services;

public class ConverterService(ICurrencyBroker currencyBroker) : IConverterService
{
    private readonly ICurrencyBroker _currencyBroker = currencyBroker;

    public decimal Convert(string input)
    {
        var arguments = input.Split().ToList();

        ValidateInput(arguments);

        (var mainCurrencyIsoCode, var moneyCurrencyIsoCode, var amount) =
            ConvertInputsToRequiredTypes(arguments);

        var mainCurrency = _currencyBroker
            .GetCurrencyByIsoCode(mainCurrencyIsoCode);

        var moneyCurrency = _currencyBroker
            .GetCurrencyByIsoCode(moneyCurrencyIsoCode);

        return amount * mainCurrency.ConversionRate / moneyCurrency.ConversionRate;
    }

    private static void ValidateInput(List<string> arguments)
    {
        CurrencyConverterValidator.ValidateInputArgumentCount(arguments);

        var command = arguments[0];
        CurrencyConverterValidator.ValidateInputCommand(command);

        var currencyPair = arguments[1];
        CurrencyConverterValidator.ValidateCurrencyPairFormat(currencyPair);

        var amount = arguments[2];
        CurrencyConverterValidator.ValidateAmount(amount);
    }

    private static (string mainCurrency, string moneyCurrency, decimal amount) ConvertInputsToRequiredTypes(
        List<string> arguments)
    {
        var currencyPair = arguments[1].Split('/');

        var mainCurrency = currencyPair[0];
        var moneyCurrency = currencyPair[1];

        var amount = decimal.Parse(arguments[2]);

        return (mainCurrency, moneyCurrency, amount);
    }
}