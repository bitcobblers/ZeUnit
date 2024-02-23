namespace ZeUnit.Lamar;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LamarContainerAttribute : ZeInjectorAttribute<LamarContainerClassComposer>
{
    public LamarContainerAttribute() : this(typeof(ServiceRegistry))
    {
    }

    public LamarContainerAttribute(Type registry) : base()
    {        
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of ServiceRegistry.");
        }

        this.Registry = registry;        
    }

    public Type Registry { get; }
}
