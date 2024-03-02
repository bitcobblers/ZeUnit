namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeBinderAttribute<LoadFileMethodComposer>
{
    public LoadFileAttribute(params string[] fileNames)
    {
        FileNames = fileNames;
    }

    public string[] FileNames { get; }
}
