namespace ZeUnit;

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
