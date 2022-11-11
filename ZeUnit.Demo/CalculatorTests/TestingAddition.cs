using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeUnit.Demo.DemoCalculator;

namespace ZeUnit.Demo.CalculatorTests
{
    public class TestingAddition
    {
        public ZeResult PassingNullValueWillResultInZero()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(0, addition.Apply(null));
        }

        public ZeResult PassingSingleValueResultWithTheValue()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(1d, addition.Apply(new[] { 1d }));
        }

        public ZeResult PassingTwoValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(3d, addition.Apply(new[] { 1d, 2d }));
        }

        public ZeResult PassingManyValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            return Ze.Is.Equal(10d, addition.Apply(new[] { 1d, 2d, 3d, 4d }));
        }
    }
}
