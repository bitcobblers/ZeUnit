namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public abstract class ZeLifeCycleAttribute : Attribute {

    public abstract ZeClassInstanceFactory GetFactory(IZeClassComposer composer, TypeInfo type);
}
