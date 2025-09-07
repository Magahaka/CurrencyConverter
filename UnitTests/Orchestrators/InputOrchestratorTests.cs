using CurrencyConverter.Interfaces.Handlers;
using CurrencyConverter.Models;
using CurrencyConverter.Orchestrators;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace UnitTests.Orchestrators;

public class InputOrchestratorTests
{
    private readonly IHandler<InputContext> _inputValidationHandler = Substitute.For<IHandler<InputContext>>();
    private readonly IHandler<InputContext> _inputParserHandler = Substitute.For<IHandler<InputContext>>();
    private readonly IHandler<InputContext> _currencyConverterHandler = Substitute.For<IHandler<InputContext>>();

    private readonly InputOrchestrator _orchestrator;

    private readonly InputContext _inputContext = new() { };

    public InputOrchestratorTests()
    {
        _inputValidationHandler
            .Handle(Arg.Any<InputContext>())
            .Returns(x => _inputParserHandler.Handle(x.Arg<InputContext>()));

        _inputParserHandler
            .Handle(Arg.Any<InputContext>())
            .Returns(x => _currencyConverterHandler.Handle(x.Arg<InputContext>()));

        _currencyConverterHandler
            .Handle(Arg.Any<InputContext>())
            .Returns(x => x.Arg<InputContext>());

        _orchestrator = new InputOrchestrator(_inputValidationHandler);
    }

    [Fact]
    public void Handle_Always_SetsUpChainOfResponsibility()
    {
        var result = _orchestrator.Handle(_inputContext);

        _inputValidationHandler
            .Received(1)
            .Handle(_inputContext);

        _inputParserHandler
            .Received(1)
            .Handle(_inputContext);

        _currencyConverterHandler
            .Received(1)
            .Handle(_inputContext);

        result
            .Should()
            .Be(_inputContext);
    }

    [Fact]
    public void Handle_WhenInputValidationFails_ShouldThrow()
    {
        var exception = new ArgumentException("exception");

        _inputValidationHandler
            .Handle(_inputContext)
            .Throws(exception);

        var result = () => _orchestrator.Handle(_inputContext);

        result
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("exception");
    }

    [Fact]
    public void Handle_WhenInputParserFails_ShouldThrow()
    {
        var exception = new ArgumentException("exception");

        _inputParserHandler
            .Handle(_inputContext)
            .Throws(exception);

        var result = () => _orchestrator.Handle(_inputContext);

        result
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("exception");
    }

    [Fact]
    public void Handle_WhenCurrencyConverterFails_ShouldThrow()
    {
        _inputValidationHandler
            .Handle(_inputContext)
            .Returns(x => _inputParserHandler.Handle(_inputContext));

        _inputParserHandler
            .Handle(_inputContext)
            .Returns(x => _currencyConverterHandler.Handle(_inputContext));

        var exception = new ArgumentException("exception");

        _currencyConverterHandler
            .Handle(_inputContext)
            .Throws(exception);

        var result = () => _orchestrator.Handle(_inputContext);

        result
            .Should()
            .Throw<ArgumentException>()
            .WithMessage("exception");
    }
}