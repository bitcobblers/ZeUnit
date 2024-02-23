// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

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
