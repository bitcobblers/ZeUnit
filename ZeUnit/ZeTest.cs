namespace ZeUnit;

public class ZeTest
{
    public string Name { get; set; }
    public IZeClassComposer ClassActivator { get; set; }

    public TypeInfo Class { get; set; }    

    public MethodInfo Method { get; set; }    

    public Func<object[]> Arguments { get; set; }
}