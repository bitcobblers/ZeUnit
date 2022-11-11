using ZeUnit.Demo.DemoCalculator.Operations;

namespace ZeUnit.Demo.DemoCalculator
{
    public class Calculator : ICalculator
    {
        protected DictionarySetter<Type, ICalculatorOperation> operations = new();

        public double? Value { get; private set; } = 0;        

        public ICalculator Register(ICalculatorOperation operation)
        {
            this.operations.Upsert(operation.GetType(), operation);
            return this;
        }

        public ICalculator Apply<TOperation>(params double[] args)
            where TOperation : ICalculatorOperation
        {
            return this.Apply(typeof(TOperation), args);            
        }

        public ICalculator Apply(Type operationType, params double[] args)
        {            
            this.Value = this.operations.TryGetValue(operationType, out var operation)
                ? operation.Apply(this.Value, args)
                : null;

            return this;
        }
    }
}
