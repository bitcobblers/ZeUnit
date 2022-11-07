using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class CheckAdditionResultsAgainst : ZeThen<CalculatorState>
    {
        private readonly int expected;

        public CheckAdditionResultsAgainst(int expected) 
            : base($"Expect to be {expected}")
        {
            this.expected = expected;
        }
        
        public override ZeResult Do(CalculatorState state)
        {
            return Ze.Is.Equal(expected, state.result);
        }
    }
}
