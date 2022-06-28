using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{    
    public class CalculatorBehavior : ZeBehavior
    {
        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        [InlineData(4, 5, 9)]
        [InlineData(5, 6, 11)]
        public IEnumerable<ZeResult> Addition(int a, int b, int expected)
        {
            // context as regular variables no fuzzy logic;
            var calulator = new Calculator();
            int result = 0;

            yield return Given($"Set first number to {a}.");
            yield return Given($"Set the second number to {b}");
            yield return When("Add numbers", () => { result = calulator.Add(a, b); });
            yield return Then("Expect ", z => z.Equal(result, expected));
        }
    }
}
