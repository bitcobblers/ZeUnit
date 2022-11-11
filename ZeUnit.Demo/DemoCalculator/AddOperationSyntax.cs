namespace ZeUnit.Demo.DemoCalculator
{
    public static class AddOperationSyntax
    {
        public static double Add(this ICalculator calc, params double[] args)
        {
            return calc.Apply<AddOperation>(args) ?? 0d;
        }
    }
}
