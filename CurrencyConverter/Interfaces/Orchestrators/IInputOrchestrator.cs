using CurrencyConverter.Models;

namespace CurrencyConverter.Interfaces.Orchestrators;

public interface IInputOrchestrator
{
    InputContext Handle(InputContext input);
}