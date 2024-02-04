using ZeUnit.Demo.DemoCalculator;
using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests
{
    public class TestingAddition
    {
        public ZeResult PassingNullValueWillResultInZero()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(0, addition.Apply(0, null!)!.Value);
        }

        public ZeResult PassingSingleValueResultWithTheValue()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(1d, addition.Apply(0, new[] { 1d })!.Value);
        }

        public ZeResult PassingTwoValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(3d, addition.Apply(0, new[] { 1d, 2d })!.Value);
        }

        public ZeResult PassingManyValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(10d, addition.Apply(0, new[] { 1d, 2d, 3d, 4d })!.Value);
        }
    }
}
