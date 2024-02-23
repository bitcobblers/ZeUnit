using System.IO.Enumeration;

namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeComposerAttribute<LoadFileMethodComposer>
{
    public LoadFileAttribute(params string[] fileNames)
    {
        FileNames = fileNames;
    }

    public string[] FileNames { get; }
}
