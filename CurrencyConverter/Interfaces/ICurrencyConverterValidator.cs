namespace CurrencyConverter.Interfaces;

public interface ICurrencyConverterValidator
{
    void ValidateInputArgumentCount(string userInput);
    void ValidateInputCommand(string command);
    void ValidateCurrencyPairFormat(string currencyPair);
    void ValidateAmount(string amount);
}