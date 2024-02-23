namespace ZeUnit;

public abstract class ZeComposerActivator
{
    protected ZeComposerActivator(ZeComposerAttribute attribute) 
        : this(new[] { attribute })
    {

    }

    protected ZeComposerActivator(ZeComposerAttribute[] attribute)
    {
        Attribute = attribute;
    }

    public ZeComposerAttribute[] Attribute { get; }
}

public abstract class ZeInjectionActivator
{
    protected ZeInjectionActivator(ZeInjectorAttribute attribute) 
        : this(new[] { attribute })
    {

    }

    protected ZeInjectionActivator(ZeInjectorAttribute[] attribute)
    {
        Attribute = attribute;
    }

    public ZeInjectorAttribute[] Attribute { get; }
}


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

public abstract class ZeInjectorAttribute : Attribute
{
    public Type Activator { get; protected set; }

    protected ZeInjectorAttribute(Type activator)
    {
        Activator = activator;
    }
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class ZeInjectorAttribute<TType> : ZeInjectorAttribute
    where TType : IZeClassComposer
{
    protected ZeInjectorAttribute() : base(typeof(TType))
    {        
    }
}