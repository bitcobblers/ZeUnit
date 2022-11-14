// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileGroupsAttribute : ZeComposerAttribute, ILoadFilesAttribute
{
    public LoadFileGroupsAttribute(string directory)
        : base(typeof(LoadDirectoryMethodComposer<LoadFileGroupsFromDirectoryFileMapper>))
    {
        this.Directory = directory;
    }

    public string Directory { get; }
}
