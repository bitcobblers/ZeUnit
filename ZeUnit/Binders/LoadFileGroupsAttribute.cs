// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileGroupsAttribute : ZeBinderAttribute<LoadDirectoryMethodComposer<LoadFileGroupsFromDirectoryFileMapper>>, ILoadFilesAttribute
{
    public LoadFileGroupsAttribute(string directory)
    {
        Directory = directory;
    }

    public string Directory { get; }
}
