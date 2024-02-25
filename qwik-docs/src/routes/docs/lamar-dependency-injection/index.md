import Warning from '~/components/template/warning'

# Coming Soon

<Warning title="Under Construction" >
    This page is under construction and may contain incomplete or incorrect information.
</Warning>


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

Behind the scenes, the `SimpleServiceInjectorRegistry` passed into the `LamarContainerAttribute` creates the container registration for `ISimpleInjectedService` with some implementation. When the testing framework calls the composer it will use the Lamar-based implementation.
