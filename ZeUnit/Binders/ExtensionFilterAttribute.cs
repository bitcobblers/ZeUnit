// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class ExtensionFilterAttribute : Attribute
{
    public ExtensionFilterAttribute(string filter)
    {
        Filter = filter;
    }

    public string Filter { get; }
}
