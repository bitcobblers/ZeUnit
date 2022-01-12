namespace ZeUnit.Lamar;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class LamarContainerAttribute : ZeComposerAttribute
{
    public LamarContainerAttribute(Type registry) 
        : base(typeof(LamarContainerClassComposer))
    {        
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of SerivceRegistry.");
        }

        this.Registry = registry;        
    }

    public Type Registry { get; }
}
