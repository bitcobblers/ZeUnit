namespace ZeUnit.Demo.InjectionTests;

[ZeLoader(typeof(SimpleInjectionFixture))]
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

    [ZeInputs(typeof(SimpleValueInjectionFixture))]
    public ZeResult MethodInjectionTestMethodThatPasses(string value)
    {        
        return Ze.Assert()
            .IsEqual("Test", value);
    }
}