namespace ZeUnit;


public abstract class ZeComposerAttribute : Attribute
{
    public Type Activator { get; protected set; }

    protected ZeComposerAttribute(Type activator)
    {
        Activator = activator;
    }
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public abstract class ZeComposerAttribute<TType> : ZeComposerAttribute
    where TType: IZeMethodBinder
{
    protected ZeComposerAttribute() : base(typeof(TType))
    {        
    }
}
