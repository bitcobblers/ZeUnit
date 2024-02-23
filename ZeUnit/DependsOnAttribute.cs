namespace ZeUnit;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class DependsOnAttribute : Attribute
{
    public DependsOnAttribute(Type @class)
    {
        Dependency = @class.FullName;
    }

    public DependsOnAttribute(string method)
    {
        Dependency = method;
    }

    public string Dependency { get; }
}