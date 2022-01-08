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
        return Ze.Assert()
            .IsNotNull(this.service);            
    }

    [LamarContainer(typeof(SimpleValueInjectionRegistry))]
    public ZeResult MethodInjectionTestMethodThatPasses(string value)
    {        
        return Ze.Assert()
            .IsEqual("Test", value);
    }
}