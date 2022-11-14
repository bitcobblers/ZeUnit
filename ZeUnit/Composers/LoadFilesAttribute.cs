// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFilesAttribute : ZeComposerAttribute, ILoadFilesAttribute
{
    public LoadFilesAttribute(string directory) 
        : base(typeof(LoadDirectoryMethodComposer<LoadSingleFileFromDirectoryFileMapper>))
    {
        this.Directory = directory;        
    }

    public string Directory { get; }    
}
