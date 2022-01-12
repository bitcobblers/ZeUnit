// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;
public class StringFileLoader : ZeTypeFileLoader<string>
{
    public override object Load(Type type, FileInfo file)
    {
        return file.OpenText().ReadToEnd();
    }
}
