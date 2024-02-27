namespace ZeUnit.Demo.CalculatorTests.DemoCalculator
{
    public interface ICalculatorOperation
    {
        double? Apply(double? current, double[] args);
    }
}
