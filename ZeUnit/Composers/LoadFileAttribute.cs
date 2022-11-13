using System.IO.Enumeration;

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeComposerAttribute
{
    public LoadFileAttribute(params string[] fileNames) 
        : base(typeof(LoadFileMethodComposer))
    {    
        this.FileNames =  fileNames;
    }

    public string[] FileNames { get; }
}
