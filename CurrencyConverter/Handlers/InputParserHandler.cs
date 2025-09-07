using CurrencyConverter.Handlers.Base;
using CurrencyConverter.Interfaces.Broker;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers;

public class InputParserHandler(ICurrencyBroker currencyBroker) : AbstractHandler
{
    public override InputContext Handle(InputContext context)
    {
        var arguments = context.UserInput
            .Split()
            .ToList();

        (var mainCurrencyIsoCode, var moneyCurrencyIsoCode, var amount) = ConvertInputsToRequiredTypes(arguments);

        var mainCurrency = currencyBroker.GetCurrencyByIsoCode(mainCurrencyIsoCode);
        var moneyCurrency = currencyBroker.GetCurrencyByIsoCode(moneyCurrencyIsoCode);

        context.SetMainCurrency(mainCurrency);
        context.SetMoneyCurrency(moneyCurrency);
        context.SetOriginalAmount(amount);

        return base.Handle(context);
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