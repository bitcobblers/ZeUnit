namespace ZeUnit.Demo.DemoCalculator
{
    public class Calculator : ICalculator
    {
        protected LatestDictionary<Type, ICalculatorOperation> operations = new();

        public Calculator Register(ICalculatorOperation operation)
        {
            this.operations.AddOrUpdate(operation.GetType(), operation);
            return this;
        }

        public double? Apply<TOperation>(params double[] args)
            where TOperation : ICalculatorOperation
        {
            return this.operations.TryGetValue(typeof(TOperation), out var operation)
                ? operation.Apply(args)
                : null;
        }
    }
}
