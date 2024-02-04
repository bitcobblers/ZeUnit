using ZeUnit.Demo.DemoCalculator;
using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests
{
    [LamarContainer(typeof(CalculatorRegistry))]
    public class TestingCalculatorIntegration
    {
        private readonly ICalculator calculator;

        public TestingCalculatorIntegration(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        [InlineData(null!, 0)]
        [InlineData(new[] { 1d }, 1)]
        [InlineData(new[] { 1d, 2d }, 3)]
        [InlineData(new[] { 1d, 2d, 3d, 4d }, 10)]
        public ZeResult AdditionHarness(double[] values, double expected)
        {            
            return Ze.Is.Equal(expected, this.calculator.Apply<AddOperation>(values)!.Value!.Value);
        }
    }
}
