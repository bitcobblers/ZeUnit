using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class CalculatorState
    {
        public int a { get; set; }
        public int b { get; set; }
        public int result { get; set; }

    }

    [LamarContainer()]
    public class CalculatorStateBehavior : ZeStateBehavior<CalculatorState>
    {
        private readonly Calculator calulator;

        public CalculatorStateBehavior(Calculator calulator)
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
            yield return this.Given(new SetFirstAdderForCalculator(a));
            yield return this.Given(new SetSecondAdderForCalculator(b));
            yield return this.When(new ApplyAddition(calulator));
            yield return this.Then(new CheckAdditionResultsAgainst(expected));
        }
    }
}
