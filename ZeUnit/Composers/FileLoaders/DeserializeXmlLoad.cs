// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Composers.FileLoaders;
using System.Xml.Serialization;

public class DeserializeXmlLoad : IZeFileLoader
{
    public bool Match(Type type, FileInfo file) => file.Extension.ToLower() == ".xml";

    public object Load(Type type, FileInfo file)
    {
        var serializer = new XmlSerializer(type);
        using var reader = file.OpenRead();
        return serializer.Deserialize(reader)!;
    }
}
