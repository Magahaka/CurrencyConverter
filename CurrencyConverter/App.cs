using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;
using CurrencyConverter.Utils;

namespace CurrencyConverter;

public class App(IInputOrchestrator inputOrchestrator)
{
    public void Run()
    {
        Console.WriteLine(Constants.ExchangeCommandUsageResponse());

        while (true)
        {
            var userInput = Console.ReadLine();

            HandleUserInput(userInput);
        }
    }

    private void HandleUserInput(string userInput)
    {
        try
        {
            var context = new InputContext
            {
                UserInput = userInput
            };

            var result = inputOrchestrator.Handle(context);

            Console.WriteLine(result.ConvertedAmount);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}