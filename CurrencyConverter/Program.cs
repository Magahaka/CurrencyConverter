using CurrencyConverter.Interfaces.Services;
using CurrencyConverter.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConverterService, ConverterService>()
            .AddSingleton<App>()
            .BuildServiceProvider();

        var app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }
}