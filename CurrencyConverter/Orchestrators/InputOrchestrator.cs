using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Interfaces.Orchestrators;
using CurrencyConverter.Models;

namespace CurrencyConverter.Orchestrators;

public class InputOrchestrator(IHandler<InputContext> firstHandler) : IInputOrchestrator
{
    private readonly IHandler<InputContext> _firstHandler = firstHandler ?? 
        throw new ArgumentNullException(nameof(firstHandler));

    public InputContext Handle(InputContext input)
    {
        return _firstHandler.Handle(input);
    }
}