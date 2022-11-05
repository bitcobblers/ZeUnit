// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit;

public class ComposerClassFactory : BaseComposerFactory<IZeClassComposer, CoreClassComposer>
{
    public IEnumerable<IZeClassComposer> Get(Type type)
    {
        return Get(type.GetCustomAttributes());
    }

}
