namespace ZeUnit;

public class ZeInputsAttribute : Attribute
{
    public ZeInputsAttribute(params Type[] loaders)
    {
        Loaders = loaders;
    }

    public Type[] Loaders { get; }
}
