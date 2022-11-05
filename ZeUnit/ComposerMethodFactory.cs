// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit;

public class ComposerMethodFactory : BaseComposerFactory<IZeMethodComposer, CoreMethodComposer>
{
    public IEnumerable<IZeMethodComposer> Get(MethodInfo method)
    {
        return Get(method.GetCustomAttributes());
    }
}
