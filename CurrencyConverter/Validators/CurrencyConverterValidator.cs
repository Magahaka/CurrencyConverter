using CurrencyConverter.Utils;

namespace CurrencyConverter.Validators;

public static class CurrencyConverterValidator
{
    public static void ValidateInputArgumentCount(List<string> arguments)
    {
        if (arguments.Count != 3)
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Incorrect number of arguments"));
        }
    }

    public static void ValidateInputCommand(string command)
    {
        if (!command.Equals("exchange", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain 'exchange' argument"));
        }
    }

    public static void ValidateCurrencyPairFormat(string currencyPair)
    {
        if (!currencyPair.Contains('/'))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct currency pair format"));
        }

        var providedCurrencies = currencyPair
            .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

        if (providedCurrencies.Length != 2)
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct currency pair format"));
        }
    }

    public static void ValidateAmount(string amount)
    {
        if (!decimal.TryParse(amount, out _))
        {
            throw new ArgumentException(
                Constants.IncorrectExchangeCommandResponse(
                    "Input must contain correct amount format"));
        }
    }
}