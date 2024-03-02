namespace ZeUnit.Demo.CalculatorTests.DemoCalculator;

public class Calculator : ICalculator
{
    protected DictionarySetter<Type, ICalculatorOperation> operations = new();

    public double? Value { get; private set; } = 0;

    public ICalculator Register(ICalculatorOperation operation)
    {
        operations.Upsert(operation.GetType(), operation);
        return this;
    }

    public ICalculator Apply<TOperation>(params double[] args)
        where TOperation : ICalculatorOperation
    {
        return Apply(typeof(TOperation), args);
    }

    public ICalculator Apply(Type operationType, params double[] args)
    {
        Value = operations.TryGetValue(operationType, out var operation)
            ? operation.Apply(Value, args)
            : null;

        return this;
    }
}
