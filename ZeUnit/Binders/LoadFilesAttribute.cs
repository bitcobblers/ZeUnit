// See https://aka.ms/new-console-template for more information


// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFilesAttribute : ZeComposerAttribute<LoadDirectoryMethodComposer<LoadSingleFileFromDirectoryFileMapper>>, ILoadFilesAttribute
{
    public LoadFilesAttribute(string directory)
    {
        Directory = directory;
    }

    public string Directory { get; }
}
