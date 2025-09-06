using CurrencyConverter.Interfaces.Services;
using CurrencyConverter.Utils;

namespace CurrencyConverter;

public class App(IConverterService converterService)
{
    private readonly IConverterService _converterService = converterService;

    public void Run()
    {
        Console.WriteLine(Constants.ExchangeCommandUsageResponse());

        while (true)
        {
            var input = Console.ReadLine();

            HandleCurrencyConversion(input);
        }
    }

    private void HandleCurrencyConversion(string input)
    {
        try
        {
            var result = _converterService.Convert(input);

            Console.WriteLine(result);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}