using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.DemoCalculator
{
    public class Calculator : ICalculator
    {
        protected DictionarySetter<Type, ICalculatorOperation> operations = new();

        public double? Value { get; private set; } = 0;        

        public ICalculator Register(ICalculatorOperation operation)
        {
            this.operations.AddOrUpdate(operation.GetType(), operation);
            return this;
        }

        public ICalculator Apply<TOperation>(params double[] args)
            where TOperation : ICalculatorOperation
        {
            this.Value = this.operations.TryGetValue(typeof(TOperation), out var operation)
                ? operation.Apply(this.Value, args)
                : null;

            return this;
        }
    }
}
