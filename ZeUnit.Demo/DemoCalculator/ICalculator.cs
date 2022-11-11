namespace ZeUnit.Demo.DemoCalculator
{
    public interface ICalculator
    {
        ICalculator Register(ICalculatorOperation operation);

        ICalculator Apply<TOperation>(params double[] args) where TOperation : ICalculatorOperation;

        ICalculator Apply(Type operation, params double[] args);

        double? Value { get; }
    }
}