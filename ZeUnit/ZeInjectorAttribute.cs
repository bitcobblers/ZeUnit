namespace ZeUnit;

public abstract class ZeInjectorAttribute : Attribute
{
    public Type Activator { get; protected set; }

    protected ZeInjectorAttribute(Type activator)
    {
        Activator = activator;
    }
}
