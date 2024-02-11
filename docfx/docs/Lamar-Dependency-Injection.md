## Coming Soon

```csharp
[LamarContainer(typeof(SimpleServiceInjectionRegistry))]
public class InjectionZeUnitClass
{
    private readonly ISimpleInjectedService service;

    public InjectionZeTestClass(ISimpleInjectedService service)
    {
        this.service = service;
    }

    public Fact ConstructorInjectionTestMethodThatPasses()
    {
        return this.service.IsNotNull();

    }
}
```

Behind the scenes, the *SimpleServiceInjectorRegistraty* that is passed into the *LamarContainerAttribute* creates the container registration for *ISimpleInjectedService* with some implementation. When the testing framework calls a Composer defined in the *LamarContainerAttribute*, this composer is responsible for creating the instance of the class.
