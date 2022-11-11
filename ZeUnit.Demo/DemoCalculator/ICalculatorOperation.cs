namespace ZeUnit.Demo.DemoCalculator
{
    public interface ICalculatorOperation
    {
        double? Apply(double? current, double[] args);
    }
}
