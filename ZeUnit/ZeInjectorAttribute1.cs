namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class ZeInjectorAttribute<TType> : ZeInjectorAttribute
    where TType : IZeClassComposer
{
    protected ZeInjectorAttribute() : base(typeof(TType))
    {        
    }
}