// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public class LoadFileTextAttribute : ZeActivatorAttribute
{
    public LoadFileTextAttribute(params string[] fileName) : base(typeof(FileTextMethodActivator))
    {
        this.FileNames = fileName;
    }

    public string[] FileNames { get; }
}

public class LoadFileStreamAttribute : ZeActivatorAttribute
{    
    public LoadFileStreamAttribute(params string[] fileName) : base(typeof(FileStreamMethodActivator))
    {
        this.FileNames = fileName;
    }

    public string[] FileNames { get; }
}
