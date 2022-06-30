using ZeUnit.Behave;

namespace ZeUnit.Demo.CalculatorBehavior
{
    public class ApplyAddition : ZeWhen<CalculatorState>
    {
        private readonly Calculator cal;        

        public ApplyAddition(Calculator cal) : base("Number are added")
        {
            this.cal = cal;            
        }

        public override void Do(CalculatorState state)
        {
            state.result = cal.Add(state.a, state.b);
        }        
    }
}
