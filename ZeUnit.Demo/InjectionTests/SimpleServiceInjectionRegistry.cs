namespace ZeUnit.Demo.InjectionTests;

public class SimpleServiceInjectionRegistry : ServiceRegistry
{
    public SimpleServiceInjectionRegistry()
    {
        For<ISimpleInjectedService>().Use<SimpleInjectedService>();
    }
}
