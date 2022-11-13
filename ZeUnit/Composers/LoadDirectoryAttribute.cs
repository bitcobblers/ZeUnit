// See https://aka.ms/new-console-template for more information

using System.Globalization;

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadDirectoryAttribute : ZeComposerAttribute
{
    public LoadDirectoryAttribute(string directory, params string[] extentions) 
        : base(typeof(LoadDirectoryMethodComposer))
    {
        this.Directory = directory;
        this.Extentions = extentions.Length > 0 ? extentions : new[] { string.Empty };
    }

    public string Directory { get; }
    public string[] Extentions { get; }
}
