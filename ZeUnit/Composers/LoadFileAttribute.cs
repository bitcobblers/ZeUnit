using System.IO.Enumeration;

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeComposerAttribute<LoadFileMethodComposer>
{
    public LoadFileAttribute(params string[] fileNames)         
    {    
        this.FileNames =  fileNames;
    }

    public string[] FileNames { get; }
}
