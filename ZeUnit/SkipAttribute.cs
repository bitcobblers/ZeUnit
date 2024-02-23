namespace ZeUnit;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
public class SkipAttribute : Attribute
{
}