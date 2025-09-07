using CurrencyConverter.Interfaces;
using CurrencyConverter.Utils;

namespace CurrencyConverter.Validators;

public class CurrencyConverterValidator : ICurrencyConverterValidator
{
    public void ValidateInputArgumentCount(string userInput)
    {
        var arguments = userInput.Split().ToList();

        if (arguments.Count != 3)
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Incorrect number of arguments"));
        }
    }

    public void ValidateInputCommand(string command)
    {
        if (!command.Equals("exchange", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain 'exchange' argument"));
        }
    }

    public void ValidateCurrencyPairFormat(string currencyPair)
    {
        if (!currencyPair.Contains('/'))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct currency pair format"));
        }

        var providedCurrencies = currencyPair
            .Split(['/'], StringSplitOptions.RemoveEmptyEntries);

        if (providedCurrencies.Length != 2)
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct currency pair format"));
        }
    }

    public void ValidateAmount(string amount)
    {
        if (!decimal.TryParse(amount, out _))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct amount format"));
        }
    }
}