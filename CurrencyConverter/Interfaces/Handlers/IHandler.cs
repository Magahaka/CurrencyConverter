using CurrencyConverter.Models;

namespace CurrencyConverter.Interfaces.Handlers;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
    InputContext Handle(InputContext input);
}