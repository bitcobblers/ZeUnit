// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeComposerAttribute
{
    public LoadFileAttribute(params string[] fileName)
        : base(typeof(LoadFileMethodComposer))
    {
        FileNames = fileName;
    }

    public string[] FileNames { get; }
}
