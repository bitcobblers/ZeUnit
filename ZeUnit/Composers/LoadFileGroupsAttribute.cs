// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileGroupsAttribute : ZeComposerAttribute<LoadDirectoryMethodComposer<LoadFileGroupsFromDirectoryFileMapper>>, ILoadFilesAttribute
{
    public LoadFileGroupsAttribute(string directory)
    {
        this.Directory = directory;
    }

    public string Directory { get; }
}
