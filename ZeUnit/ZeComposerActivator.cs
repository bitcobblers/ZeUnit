namespace ZeUnit;

public abstract class ZeBinderActivator
{
    protected ZeBinderActivator(ZeBinderAttribute attribute) 
        : this(new[] { attribute })
    {
    }

    protected ZeBinderActivator(ZeBinderAttribute[] attribute)
    {
        Attribute = attribute;
    }

    public ZeBinderAttribute[] Attribute { get; }
}
