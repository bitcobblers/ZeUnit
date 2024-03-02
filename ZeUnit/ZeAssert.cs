namespace ZeUnit;

public class ZeAssert
{
    public ZeStatus Status { get; set; }
    public string Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return Message != null 
            ? $"[{Status}] : {Message}"
            : $"[{Status}]";
    }
}