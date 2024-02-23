namespace ZeUnit.Composers;

public abstract class ZeComposerAttribute : Attribute
{
    public Type Activator { get; protected set; }

    protected ZeComposerAttribute(Type activator)
    {
        Activator = activator;
    }
}
