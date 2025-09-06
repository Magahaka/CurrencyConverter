using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;

namespace CurrencyConverter.CurrencyProviders;

public class InputOrchestrator : IInputOrchestrator
{
    private readonly IInputValidationHandler _inputValidationHandler;
    private readonly IInputParserHandler _inputParserHandler;
    private readonly ICurrencyConverterHandler _currencyConverterHandler;

    public InputOrchestrator(
        IInputValidationHandler inputValidationHandler,
        IInputParserHandler inputParserHandler,
        ICurrencyConverterHandler currencyConverterHandler)
    {
        _inputValidationHandler = inputValidationHandler;
        _inputParserHandler = inputParserHandler;
        _currencyConverterHandler = currencyConverterHandler;

        _inputValidationHandler
            .SetNext(_inputParserHandler)
            .SetNext(_currencyConverterHandler);
    }

    public InputContext Handle(InputContext input)
    {
        return _inputValidationHandler.Handle(input);
    }
}