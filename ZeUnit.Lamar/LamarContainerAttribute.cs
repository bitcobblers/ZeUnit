namespace ZeUnit;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LamarContainerAttribute : Attribute
{
    public LamarContainerAttribute(Type registry)
    {
        if (!registry.IsAssignableTo(typeof(ServiceRegistry)))
        {
            throw new InvalidDataException("Lamar container must register a type of SerivceRegistry.");
        }

        Registry = registry;

    }

    public Type Registry { get; }
}
