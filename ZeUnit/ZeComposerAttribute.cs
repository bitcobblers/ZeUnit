namespace ZeUnit;

public abstract class ZeComposerAttribute : Attribute
{    
    protected ZeComposerAttribute(Type type)
    {
        this.Activator = type;
    }

    public Type Activator { get; }    
}
