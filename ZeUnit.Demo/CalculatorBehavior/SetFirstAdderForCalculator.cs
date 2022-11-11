using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class SetFirstAdderForCalculator : ZeGiven<CalculatorState>
    {
        private readonly double adder;

        public SetFirstAdderForCalculator(double adder)
            : base($"Added the first adder with value of '{adder}'.")
        {
            this.adder = adder;
        }

        public override void Do(CalculatorState state)
        {
            state.a = adder;
        }
    }
}
