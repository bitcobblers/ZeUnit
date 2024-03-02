using ZeUnit.Demo.CalculatorTests.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests.DemoCalculator;

public class CalculatorRegistry : ServiceRegistry
{
    public CalculatorRegistry()
    {
        For<ICalculator>().Use(service => new Calculator()
            .Register(new AddOperation())
            .Register(new SubtractOperation()));
    }
}
