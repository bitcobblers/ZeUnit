namespace ZeUnit;

public class ZeTest
{
    public TypeInfo Class { get; set; }

    public IZeClassComposer ClassActivator { get; set; }

    public MethodInfo Method { get; set; }

    public IZeMethodComposer MethdoActivator { get; set; }
}