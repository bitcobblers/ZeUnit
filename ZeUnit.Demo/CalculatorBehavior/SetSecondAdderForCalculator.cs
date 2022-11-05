using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class SetSecondAdderForCalculator : ZeGiven<CalculatorState>
    {
        private readonly int adder;

        public SetSecondAdderForCalculator(int adder)
            : base($"Added the second adder with value of '{adder}'.")
        {
            this.adder = adder;
        }

        public override void Do(CalculatorState state)
        {
            state.b = adder;
        }
    }
}
