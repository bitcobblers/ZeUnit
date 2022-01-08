namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ZeLoaderAttribute : Attribute
{
    public ZeLoaderAttribute(Type loader)
    {
        Loader = loader;
    }

    public Type Loader { get; }
}
