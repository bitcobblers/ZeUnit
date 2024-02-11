namespace ZeUnit.Demo.InjectionTests;

[LamarContainer(typeof(SimpleServiceInjectionRegistry))]
public class InjectionZeTestClass
{
    private readonly ISimpleInjectedService service;

    public InjectionZeTestClass(ISimpleInjectedService service)
    {
        this.service = service;
    }

    public Fact ConstructorInjectionTestMethodThatPasses()
    {
        return new Fact(this.service)  
            .IsNotNull();

    }
}