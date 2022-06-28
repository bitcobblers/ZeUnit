using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{    
    [LamarContainer()]
    public class CalculatorBehavior : ZeClosureBehavior
    {
        private readonly Calculator calulator;

        public CalculatorBehavior(Calculator calulator)
        {            
            this.calulator = calulator;
        }

        [InlineData(1, 2, 3)]
        [InlineData(2, 3, 5)]
        [InlineData(3, 4, 7)]
        [InlineData(4, 5, 9)]
        [InlineData(5, 6, 11)]
        public IEnumerable<ZeResult> Addition(int a, int b, int expected)
        {
            // Context is the variables defined in this scope.
            int result = 0;
            
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
