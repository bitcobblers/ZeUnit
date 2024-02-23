// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders.FileLoaders;

public class FileStreamFileLoader : ZeTypeFileLoader<FileStream>
{
    public override object Load(Type type, FileInfo file)
    {
        return file.OpenRead();
    }
}
