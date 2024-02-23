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
