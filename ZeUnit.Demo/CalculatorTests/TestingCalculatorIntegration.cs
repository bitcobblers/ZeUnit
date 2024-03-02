using ZeUnit.Demo.CalculatorTests.DemoCalculator;
using ZeUnit.Demo.CalculatorTests.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests;

[LamarContainer(typeof(CalculatorRegistry))]
public class TestingCalculatorIntegration(ICalculator calculator)
{    
    [InlineData(null!, 0)]
    [InlineData(new[] { 1d }, 1)]
    [InlineData(new[] { 1d, 2d }, 3)]
    [InlineData(new[] { 1d, 2d, 3d, 4d }, 10)]
    public Fact AdditionHarness(double[] values, double expected)
    {            
        return calculator.Apply<AddOperation>(values)!.Value!.Value.Is(expected);
    }
}
