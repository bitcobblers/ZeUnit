namespace ZeUnit;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class LamarContainerAttribute : Attribute
{
    public LamarContainerAttribute(Type registry)
    {
        Registry = registry;
    }

    public Type Registry { get; }
}
