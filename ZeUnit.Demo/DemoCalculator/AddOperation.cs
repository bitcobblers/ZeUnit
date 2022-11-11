namespace ZeUnit.Demo.DemoCalculator
{
    public class AddOperation : ICalculatorOperation
    {
        public double Apply(double[] args)
        {
            return (args ?? Array.Empty<double>()).Aggregate(0d, (sum, current) => sum + current);
        }
    }
}
