namespace ZeUnit.Demo.CalculatorTests.DemoCalculator.Operations
{
    public class AddOperation : ICalculatorOperation
    {
        public double? Apply(double? current, double[] args)
        {
            return (args ?? Array.Empty<double>()).Aggregate(0d, (sum, current) => sum + current);
        }
    }
}
