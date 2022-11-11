namespace ZeUnit.Demo.DemoCalculator
{
    public interface ICalculator
    {
        double? Apply<TOperation>(params double[] args) where TOperation : ICalculatorOperation;
        Calculator Register(ICalculatorOperation operation);
    }
}