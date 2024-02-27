namespace ZeUnit.Demo.InjectionTests;

[LamarContainer(typeof(SimpleServiceInjectionRegistry))]
public class InjectionZeTestClass(ISimpleInjectedService service)
{    
    public Fact ConstructorInjectionTestMethodThatPasses()
    {
        return new Fact(service)  
            .IsNotNull();

    }
}