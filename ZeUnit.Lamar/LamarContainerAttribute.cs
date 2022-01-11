namespace ZeUnit.Lamar;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LamarContainerAttribute : ZeActivatorAttribute
{
    public LamarContainerAttribute(Type registry) 
        : base(typeof(LamarClassActivator))
    {        
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of SerivceRegistry.");
        }

        this.Registry = registry;        
    }

    public Type Registry { get; }
}
