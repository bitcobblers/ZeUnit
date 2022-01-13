namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public abstract class ZeLifeCycleAttribute : Attribute {

    public abstract ZeClassInstanceFactory Create(IZeClassComposer composer, TypeInfo type);
}
