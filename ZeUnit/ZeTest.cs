namespace ZeUnit;
public record MethodCodeInfo(
        string FileName,
        int LineNumber,
        string Namespace,
        string ClassName,
        string MethodName,
        string Lifestyle,
        string[] Requires);

public class ZeTest
{
    public string Name { get; set; } = string.Empty;
    
    public bool Skipped { get; set; } = false;

    public IZeClassFactory? ClassFactory { get; set; }
    
    public TypeInfo? Class { get; set; }    

    public MethodCodeInfo CodeInfo { get; set; }

    public MethodInfo? Method { get; set; }    

    public Func<object[]>? Arguments { get; set; }    

    public string[]? DependsOn { get; set; }
}