using ZeUnit.Composers;

namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class ZeComposerAttribute<TType> : ZeComposerAttribute
    where TType : IZeClassComposer
{
    protected ZeComposerAttribute() : base(typeof(TType))
    {        
    }
}