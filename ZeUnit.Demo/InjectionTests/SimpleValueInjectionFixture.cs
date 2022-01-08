namespace ZeUnit.Demo.InjectionTests;

public class SimpleValueInjectionFixture : ZeContainerLoader
{
    public override IEnumerable<ServiceRegistry> Registration()
    {
        yield return new SimpleValueInjectionRegistry();
    }
}