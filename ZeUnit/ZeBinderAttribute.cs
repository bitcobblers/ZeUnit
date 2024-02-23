namespace ZeUnit;


public abstract class ZeBinderAttribute : Attribute
{
    public Type Activator { get; protected set; }

    protected ZeBinderAttribute(Type activator)
    {
        Activator = activator;
    }
}


[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public abstract class ZeBinderAttribute<TType> : ZeBinderAttribute
    where TType: IZeMethodBinder
{
    protected ZeBinderAttribute() : base(typeof(TType))
    {        
    }
}
