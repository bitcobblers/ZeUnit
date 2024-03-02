namespace ZeUnit;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class SkipAttribute : Attribute
{
    public SkipAttribute(string reason = "Skipped with Attribute")
    {
        Reason = reason;
    }

    public string Reason { get; }
}