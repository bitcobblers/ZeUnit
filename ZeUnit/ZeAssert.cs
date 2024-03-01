namespace ZeUnit;

public class ZeAssert
{
    public virtual ZeStatus Status { get; set; }
    public virtual string Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return Message != null 
            ? $"[{Status}] : {Message}"
            : $"[{Status}]";
    }
}