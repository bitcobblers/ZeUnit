// See https://aka.ms/new-console-template for more information

using System.Globalization;

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadDirectoryAttribute : ZeComposerAttribute
{
    public LoadDirectoryAttribute(string directory) 
        : base(typeof(LoadDirectoryMethodComposer))
    {
        this.Directory = directory;        
    }

    public string Directory { get; }    
}

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
public class ExtensionFilterAttribute : Attribute
{
    public ExtensionFilterAttribute(string filter)
    {
        Filter = filter;
    }

    public string Filter { get; }
}
