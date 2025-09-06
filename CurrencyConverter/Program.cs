using CurrencyConverter.CurrencyProviders;
using CurrencyConverter.Handlers;
using CurrencyConverter.Interfaces.Broker;
using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Interfaces.Orchestrators;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IInputValidationHandler, InputValidationHandler>()
            .AddSingleton<IInputParserHandler, InputParserHandler>()
            .AddSingleton<ICurrencyConverterHandler, CurrencyConverterHandler>()
            .AddSingleton<IInputOrchestrator, InputOrchestrator>()
            .AddSingleton<ICurrencyBroker, CurrencyBroker>()
            .AddSingleton<App>()
            .BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }
}