namespace ZeUnit.Lamar;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LamarContainerAttribute : ZeActivatorAttribute
{
    public LamarContainerAttribute(Type registry)
    {        
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of SerivceRegistry.");
        }

        this.Registry = registry;
        this.WithActivator<LamarTestActivator>();

    }

    public Type Registry { get; }
}
