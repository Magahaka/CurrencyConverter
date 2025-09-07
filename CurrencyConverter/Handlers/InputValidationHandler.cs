using CurrencyConverter.Handlers.Base;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers;

public class InputValidationHandler(ICurrencyConverterValidator currencyConverterValidator) : AbstractHandler
{
    public override InputContext Handle(InputContext input)
    {
        currencyConverterValidator.ValidateInputArgumentCount(input.UserInput);

        var arguments = input.UserInput
            .Split()
            .ToList();

        var command = arguments[0];
        currencyConverterValidator.ValidateInputCommand(command);

        var currencyPair = arguments[1];
        currencyConverterValidator.ValidateCurrencyPairFormat(currencyPair);

        var amount = arguments[2];
        currencyConverterValidator.ValidateAmount(amount);

        return base.Handle(input);
    }
}