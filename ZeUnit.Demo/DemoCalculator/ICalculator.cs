namespace ZeUnit.Demo.DemoCalculator
{
    public interface ICalculator
    {
        ICalculator Register(ICalculatorOperation operation);

        ICalculator Apply<TOperation>(params double[] args) where TOperation : ICalculatorOperation;        

        double? Value { get; }
    }
}