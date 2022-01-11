namespace ZeUnit;

public abstract class ZeActivatorAttribute : Attribute
{    
    protected ZeActivatorAttribute(Type type)
    {
        this.Activator = type;
    }

    public Type Activator { get; }    
}
