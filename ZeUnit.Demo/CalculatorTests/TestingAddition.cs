using ZeUnit.Demo.DemoCalculator;
using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorTests
{
    public class TestingAddition
    {
        public Ze PassingNullValueWillResultInZero()
        {
            var addition = new AddOperation();
            return addition.Apply(0, null!)!.Value.Is(0);
        }

        public Ze PassingSingleValueResultWithTheValue()
        {
            var addition = new AddOperation();
            return addition.Apply(0, new[] { 1d })!.Value.Is(1d);
        }

        public Ze PassingTwoValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return addition.Apply(0, new[] { 1d, 2d })!.Value.Is(3d);
        }

        public Ze PassingManyValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return addition.Apply(0, new[] { 1d, 2d, 3d, 4d })!.Value.Is(10d);
        }
    }
}
