using CurrencyConverter.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter;

public class Program
{
    public static void Main()
    {
        var serviceProvider = ServiceProviderHelper.BuildServiceProvider();
        var app = serviceProvider.GetRequiredService<App>();
        app.Run();
    }
}