using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;
using CurrencyConverter.Utils;

namespace CurrencyConverter;

public class App(IInputOrchestrator inputOrchestrator)
{
    private readonly IInputOrchestrator _inputOrchestrator = inputOrchestrator;

    public void Run()
    {
        Console.WriteLine(Constants.ExchangeCommandUsageResponse());

        while (true)
        {
            var userInput = Console.ReadLine();

            var inputModel = new InputContext
            {
                UserInput = userInput
            };

            HandleCurrencyConversion(inputModel);
        }
    }

    private void HandleCurrencyConversion(InputContext inputModel)
    {
        try
        {
            var context = _inputOrchestrator.Handle(inputModel);

            Console.WriteLine(context.ConvertedAmount);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}