namespace ZeUnit.Demo.LamarInjectionTests;

public class SimpleServiceInjectionRegistry : ServiceRegistry
{
    public SimpleServiceInjectionRegistry()
    {
        For<ISimpleInjectedService>().Use<SimpleInjectedService>();
    }
}
