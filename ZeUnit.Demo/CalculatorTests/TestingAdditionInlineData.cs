using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests
{
    public class TestingAdditionInlineData
    {
        [InlineData(null!, 0)]
        [InlineData(new[] { 1d }, 1)]
        [InlineData(new[] { 1d, 2d }, 3)]
        [InlineData(new[] { 1d, 2d, 3d, 4d }, 10)]
        public ZeResult AdditionHarness(double[] values, double expected)
        {
            var addition = new AddOperation();
            var result = addition.Apply(0, values)!.Value;
            return result.Is(expected);
        }
    }
}
