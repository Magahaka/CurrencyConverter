using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers.Base;

public abstract class AbstractHandler : IHandler
{
    private IHandler _nextHandler;

    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;

        return handler;
    }

    public virtual InputContext Handle(InputContext context)
    {
        return _nextHandler?.Handle(context);
    }
}