// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;

namespace ZeUnit.Binders.FileLoaders;

public class XDocumentFileLoader : ZeTypeFileLoader<XDocument>
{
    public override object Load(Type type, FileInfo file)
    {
        return XDocument.Load(file.OpenText().ReadToEnd());
    }
}
