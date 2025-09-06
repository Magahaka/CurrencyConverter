using CurrencyConverter.Handlers.Base;
using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Models;
using CurrencyConverter.Validators;

namespace CurrencyConverter.Handlers;

public class InputValidationHandler : AbstractHandler, IInputValidationHandler
{
    public override InputContext Handle(InputContext input)
    {
        var arguments = input.UserInput
            .Split()
            .ToList();

        CurrencyConverterValidator.ValidateInputArgumentCount(arguments);

        var command = arguments[0];
        CurrencyConverterValidator.ValidateInputCommand(command);

        var currencyPair = arguments[1];
        CurrencyConverterValidator.ValidateCurrencyPairFormat(currencyPair);

        var amount = arguments[2];
        CurrencyConverterValidator.ValidateAmount(amount);

        return base.Handle(input);
    }
}