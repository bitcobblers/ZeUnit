namespace ZeUnit.Demo.InjectionTests;

[LamarContainer(typeof(SimpleServiceInjectionRegistry))]
public class InjectionZeTestClass
{
    private readonly ISimpleInjectedService service;

    public InjectionZeTestClass(ISimpleInjectedService service)
    {
        this.service = service;
    }

    public ZeResult ConstructorInjectionTestMethodThatPasses()
    {
        return Ze.Is  
            .NotNull(this.service);

    }
}