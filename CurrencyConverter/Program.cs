using CurrencyConverter.CurrencyProviders;
using CurrencyConverter.Services;
using CurrencyConverter.Utils;

namespace CurrencyConverter;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Constants.ExchangeCommandUsageResponse());

        var currencyBroker = new CurrencyBroker();
        var converterService = new ConverterService(currencyBroker);

        while (true)
        {
            var input = Console.ReadLine();

            HandleCurrencyConversion(converterService, input);
        }
    }

    private static void HandleCurrencyConversion(
        ConverterService converterService,
        string input)
    {
        try
        {
            var result = converterService.Convert(input);

            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}