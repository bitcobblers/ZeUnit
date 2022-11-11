using ZeUnit.Behave;
using ZeUnit.Demo.DemoCalculator;
using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class ApplyAddition : ZeWhen<CalculatorState>
    {
        private readonly ICalculator cal;        

        public ApplyAddition(ICalculator cal) : base("Number are added")
        {
            this.cal = cal;            
        }

        public override void Do(CalculatorState state)
        {
            state.result = cal.Apply<AddOperation>(state.a, state.b).Value ?? 0;
        }
    }
}