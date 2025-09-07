using CurrencyConverter.Brokers;
using CurrencyConverter.Handlers;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Interfaces.Broker;
using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;
using CurrencyConverter.Orchestrators;
using CurrencyConverter.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter.Helpers;

public class ServiceProviderHelper
{
    public static IServiceProvider BuildServiceProvider()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IHandler<InputContext>, InputValidationHandler>()
            .AddSingleton<IHandler<InputContext>, InputParserHandler>()
            .AddSingleton<IHandler<InputContext>, CurrencyConverterHandler>()
            .AddSingleton<IInputOrchestrator>(sp =>
            {
                var handlers = sp.GetServices<IHandler<InputContext>>().ToList();

                if (handlers.Count == 0)
                {
                    throw new InvalidOperationException("No handlers registered.");
                }

                IHandler<InputContext> firstHandler = handlers.First();
                IHandler<InputContext> current = firstHandler;

                foreach (var handler in handlers.Skip(1))
                {
                    current = current.SetNext(handler);
                }

                return new InputOrchestrator(firstHandler);
            })
            .AddSingleton<ICurrencyBroker, CurrencyBroker>()
            .AddSingleton<ICurrencyConverterValidator, CurrencyConverterValidator>()
            .AddSingleton<App>()
            .BuildServiceProvider();

        return serviceProvider;
    }
}