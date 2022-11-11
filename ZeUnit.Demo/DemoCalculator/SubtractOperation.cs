namespace ZeUnit.Demo.DemoCalculator
{
    public class SubtractOperation : ICalculatorOperation
    {
        public double Apply(double[] args)
        {
            return args
                .Select((value, index) => (value, index))
                .Aggregate(0d, (sum, indexPair) => indexPair.index == 0 ? indexPair.value : (sum + indexPair.value));
        }
    }
}
