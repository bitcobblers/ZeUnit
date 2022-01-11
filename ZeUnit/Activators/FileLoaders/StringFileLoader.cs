// See https://aka.ms/new-console-template for more information
namespace ZeUnit.Activators;
public class StringFileLoader : ZeTypeFileLoader<string>
{
    public override object Load(Type type, FileInfo file)
    {
        return (object)file.OpenText().ReadToEnd();
    }
}
