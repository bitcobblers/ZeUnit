// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class LoadFileAttribute : ZeActivatorAttribute
{    
    public LoadFileAttribute(params string[] fileName) : base(typeof(FileReaderMethodActivator))
    {
        this.FileNames = fileName;
    }

    public string[] FileNames { get; }
}
