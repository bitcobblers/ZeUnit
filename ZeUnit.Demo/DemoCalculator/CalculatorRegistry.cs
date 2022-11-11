namespace ZeUnit.Demo.DemoCalculator
{
    public class CalculatorRegistry : ServiceRegistry
    {
        public CalculatorRegistry()
        {
            this.For<ICalculator>().Use(service => new Calculator()
                .Register(new AddOperation())
                .Register(new SubtractOperation()));
        }
    }
}
