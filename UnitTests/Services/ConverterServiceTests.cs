using CurrencyConverter.CurrencyProviders;
using CurrencyConverter.Services;

namespace UnitTests.Services
{
    public class ConverterServiceTests
    {
        private readonly ConverterService _sut;
        private readonly ICurrencyBroker _currencyBroker;

        public ConverterServiceTests()
        {
            _currencyBroker = new CurrencyBroker();
            _sut = new ConverterService(_currencyBroker);
        }

        [Fact]
        public void Convert_ShouldReturnDecimal_WhenAllParametersAreValid()
        {
            // Arrange
            var input = $"Exchange EUR/DKK 1";

            // Act
            var result = _sut.Convert(input);

            // Assert
            Assert.IsType<decimal>(result);
        }

        [Theory]
        [InlineData("EUR", "DKK", 2)]
        [InlineData("DKK", "EUR", 2)]
        [InlineData("EUR", "USD", 2)]
        [InlineData("USD", "EUR", 2)]
        [InlineData("DKK", "USD", 2)]
        [InlineData("USD", "DKK", 2)]
        public void Convert_ShouldConvert_WhenAllParametersAreValid(
            string mainCurrencyIsoCode,
            string moneyCurrencyIsoCode,
            decimal amount)
        {
            // Arrange

            var input = $"Exchange {mainCurrencyIsoCode}/{moneyCurrencyIsoCode} {amount}";

            var mainCurrency = _currencyBroker.GetCurrencyByIsoCode(mainCurrencyIsoCode);
            var moneyCurrency = _currencyBroker.GetCurrencyByIsoCode(moneyCurrencyIsoCode);

            var expectedResult = amount * mainCurrency.ConversionRate / moneyCurrency.ConversionRate;

            // Act
            var result = _sut.Convert(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Convert_ShouldThrowException_WhenArgumentCountIsIncorrect()
        {
            // Arrange
            var input = "EUR/DKK 1";

            var expectedResult =
                "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>" +
                "\nReason: Incorrect number of arguments";

            // Act
            var result = Assert.Throws<ArgumentException>(() => _sut.Convert(input));

            // Assert
            Assert.Equal(expectedResult, result.Message);
        }

        [Fact]
        public void Convert_ShouldThrowException_WhenCommandIsIncorrect()
        {
            // Arrange
            var input = "excange EUR/DKK 1";

            var expectedResult =
                "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>" +
                "\nReason: Input must contain 'exchange' argument";

            // Act
            var result = Assert.Throws<ArgumentException>(() => _sut.Convert(input));

            // Assert
            Assert.Equal(expectedResult, result.Message);
        }

        [Theory]
        [InlineData("exchange EUR-DKK 1")]
        [InlineData("exchange EUR/ 1")]
        public void Convert_ShouldThrowException_WhenCurrencyPairArgumentIsIncorrect(string input)
        {
            // Arrange

            var expectedResult =
                "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>" +
                "\nReason: Input must contain correct currency pair format";

            // Act
            var result = Assert.Throws<ArgumentException>(() => _sut.Convert(input));

            // Assert
            Assert.Equal(expectedResult, result.Message);
        }

        [Fact]
        public void Convert_ShouldThrowException_WhenAmountArgumentIsIncorrect()
        {
            // Arrange
            var input = "exchange EUR/DKK a";

            var expectedResult =
                "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>" +
                "\nReason: Input must contain correct amount format";

            // Act
            var result = Assert.Throws<ArgumentException>(() => _sut.Convert(input));

            // Assert
            Assert.Equal(expectedResult, result.Message);
        }

        [Fact]
        public void Convert_ShouldThrowException_WhenCurrencyNotFound()
        {
            // Arrange
            var input = "exchange EUR/LT 2";

            var expectedResult =
                "Invalid command format. Usage: Exchange <currency pair> <amount to exchange>" +
                "\nReason: Currency with ISO code LT not found";

            // Act
            var result = Assert.Throws<KeyNotFoundException>(() => _sut.Convert(input));

            // Assert
            Assert.Equal(expectedResult, result.Message);
        }
    }
}
