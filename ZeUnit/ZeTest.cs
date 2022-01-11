namespace ZeUnit;

public class ZeTest
{
    public TypeInfo Class { get; set; }

    public IZeClassActivator ClassActivator { get; set; }

    public MethodInfo Method { get; set; }

    public IZeMethodActivator MethdoActivator { get; set; }
}