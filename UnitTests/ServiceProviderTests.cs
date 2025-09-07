using CurrencyConverter.Handlers;
using CurrencyConverter.Helpers;
using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests;

public class ServiceProviderTests
{
    [Fact]
    public void BuildServiceProvider_RegistersHandlersInExpectedOrder()
    {
        var sp = ServiceProviderHelper.BuildServiceProvider();

        var handlers = sp.GetServices<IHandler<InputContext>>().ToList();

        handlers
            .Should()
            .HaveCount(3);

        handlers[0].Should().BeOfType<InputValidationHandler>();
        handlers[1].Should().BeOfType<InputParserHandler>();
        handlers[2].Should().BeOfType<CurrencyConverterHandler>();
    }

    [Fact]
    public void BuildServiceProvider_ResolvesInputOrchestratorSuccessfully()
    {
        var sp = ServiceProviderHelper.BuildServiceProvider();

        var orchestrator = sp.GetRequiredService<IInputOrchestrator>();

        orchestrator.Should().NotBeNull();
    }
}