// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFilesAttribute : ZeComposerAttribute<LoadDirectoryMethodComposer<LoadSingleFileFromDirectoryFileMapper>>, ILoadFilesAttribute
{
    public LoadFilesAttribute(string directory) 
    {
        this.Directory = directory;        
    }

    public string Directory { get; }    
}
