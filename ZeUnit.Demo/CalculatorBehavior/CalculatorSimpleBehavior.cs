using System;
using ZeUnit.Behave;
using ZeUnit.Demo.DemoCalculator;

namespace ZeUnit.Demo.CalculatorBehavior
{    
    [LamarContainer(typeof(CalculatorRegistry))]
    public class CalculatorSimpleBehavior : ZeSimpleBehavior
    {
        private readonly ICalculator calulator;

        public CalculatorSimpleBehavior(ICalculator calulator)
        {            
            this.calulator = calulator;
        }

        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        [InlineData(4, 5, 9)]
        [InlineData(5, 6, 11)]
        public IEnumerable<ZeResult> Addition(double a, double b, double expected)
        {
            // Context is the variables defined in this scope.
            double result = 0;
            
            // these could also have an action, but by default it is empty.
            // Given in this case is mostly a reporting too, while the method injection actually
            // passes the "given" values
            yield return Given($"Set first number to {a}.");           
            yield return Given($"Set the second number to {b}", () => { Console.WriteLine("Some Action"); });

            // When fuctions effect the state of the variables defined in this function.
            // In this example result is set to the returned sum.
            yield return When("Number are added", () => { result = calulator.Add(a, b); });

            // Finally Then is the test method, so a ZeResult is expected.
            yield return Then($"Expect {result} to be {expected}", () => Ze.Is.Equal(result, expected));
        }
    }
}
