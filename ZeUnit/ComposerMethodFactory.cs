// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit;

public class ComposerMethodFactory : BaseComposerFactory<CoreMethodComposer>
{
    public override CoreMethodComposer Create(Type defaultType)
    {
        return new CoreMethodComposer();
    }

    public IEnumerable<IZeMethodBinder> Get(MethodInfo method)
    {
        return Get(method.GetCustomAttributes());
    }
}
