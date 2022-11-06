namespace ZeUnit;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class ZeIgnoreAttribute : Attribute
{
}


[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public abstract class ZeLifeCycleAttribute : Attribute {

    public abstract ZeClassInstanceFactory GetFactory(IZeClassComposer composer, TypeInfo type);
}
