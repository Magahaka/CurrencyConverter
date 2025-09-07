using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Models;

namespace CurrencyConverter.Handlers.Base;

public abstract class AbstractHandler : IHandler<InputContext>
{
    private IHandler<InputContext> _nextHandler;

    public IHandler<InputContext> SetNext(IHandler<InputContext> handler)
    {
        _nextHandler = handler;

        return handler;
    }

    public virtual InputContext Handle(InputContext context)
    {
        return _nextHandler?.Handle(context);
    }
}