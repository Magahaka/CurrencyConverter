using CurrencyConverter.CurrencyProviders;
using CurrencyConverter.Handlers;
using CurrencyConverter.Models;
using FluentAssertions;

namespace UnitTests.Handlers;

public class CurrencyConverterHandlerTests
{
    private readonly CurrencyConverterHandler _handler;
    private readonly InputContext _inputContext;

    public CurrencyConverterHandlerTests()
    {
        _handler = new();

        _inputContext = new InputContext();
        
        
    }

    [Fact]
    public void Handle_ConvertAmount_Successfully()
    {
        _inputContext.SetOriginalAmount(1M);
        _inputContext.SetMainCurrency(new Euro());
        _inputContext.SetMoneyCurrency(new UnitedStatesDollar());

        var result = _handler.Handle(_inputContext);

        result.ConvertedAmount.Should().NotBe(decimal.Zero);
    }

    [Fact]
    public void Handle_MoneyCurrencyConversionRateIsZero_ThrowsException()
    {
        _inputContext.SetOriginalAmount(1M);
        _inputContext.SetMainCurrency(new Euro());
        _inputContext.SetMoneyCurrency(new UnitedStatesDollar() { ConversionRate = decimal.Zero });
        
        var result = () => _handler.Handle(_inputContext);

        result
            .Should()
            .Throw<DivideByZeroException>()
            .WithMessage("The conversion rate of the money currency cannot be zero.");
    }
}
