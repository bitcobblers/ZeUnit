using ZeUnit.Composers;

namespace ZeUnit;

public abstract class ZeClassComposer<TAttribute> : IZeClassComposer
    where TAttribute : ZeComposerAttribute
{
    protected ZeClassComposer(ZeComposerAttribute attribute) : this(new []{ attribute })
    {
    }

    protected ZeClassComposer(ZeComposerAttribute[] attributes) 
    {
        Attributes = attributes
            .Where(n => n.GetType().IsAssignableTo(typeof(TAttribute)))
            .Select(n => (TAttribute)n)
            .ToArray();
    }

    public TAttribute[] Attributes { get; }

    public abstract object? Get(Type args);
}
