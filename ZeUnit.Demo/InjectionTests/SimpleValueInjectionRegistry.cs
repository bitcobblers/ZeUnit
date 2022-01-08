namespace ZeUnit.Demo.InjectionTests;

public class SimpleValueInjectionRegistry : ServiceRegistry
{
    public SimpleValueInjectionRegistry()
    {
        For<string>().Use("Test");
    }
}
