namespace ZeUnit.Demo.LamarInjectionTests;

public class SimpleValueInjectionRegistry : ServiceRegistry
{
    public SimpleValueInjectionRegistry()
    {
        For<string>().Use("Test");
    }
}
