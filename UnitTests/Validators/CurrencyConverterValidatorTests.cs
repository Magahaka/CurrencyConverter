using CurrencyConverter.Validators;
using FluentAssertions;

namespace UnitTests.Validators;

public class CurrencyConverterValidatorTests
{
    private readonly CurrencyConverterValidator _validator;

    private readonly string _validUserInput = "Exchange USD/EUR 100";
    private readonly string _invalidUserInput = "Exchange USD/EUR";

    public CurrencyConverterValidatorTests()
    {
        _validator = new CurrencyConverterValidator();
    }

    [Fact]
    public void ValidateINputArgumentCount_ValidCount_DoesNotThrow()
    {
        var result = () => _validator.ValidateInputArgumentCount(_validUserInput);

        result.Should().NotThrow();
    }

    [Fact]
    public void ValidateInputArgumentCount_InvalidCount_ThrowsArgumentException()
    {
        var result = () => _validator.ValidateInputArgumentCount(_invalidUserInput);

        result
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("Invalid command format. Usage: Exchange <currency pair> <amount to exchange>\nReason: Incorrect number of arguments");
    }
}