namespace ZeUnit.Composers;

public static class ZeSingletonContainer
{
    public static Dictionary<Type, object> State { get; set; } = new Dictionary<Type, object>();
}
