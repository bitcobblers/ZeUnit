namespace ZeUnit.Demo.AutofacInjectionTests;

public class SimpleValueInjectionRegistry : ServiceRegistry
{
    public SimpleValueInjectionRegistry()
    {
        For<string>().Use("Test");
    }
}
