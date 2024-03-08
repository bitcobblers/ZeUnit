using FakeItEasy;
using ZeUnit.Composers;

namespace ZeUnit.FakeItEasy;

public class FakeClassComposer<TType> : IZeClassComposer
    where TType : class
{
    private readonly IFakeComposer<TType>? composer;

    public FakeClassComposer(ZeComposerAttribute attributes)
    {
        this.composer = attributes as IFakeComposer<TType>;
    }

    public object? Get(Type args)
    {
        var genericType = args.GetGenericArguments().FirstOrDefault();
        if (genericType != null && genericType == typeof(TType))
        {
            return composer?.Create();            
        }
        return default;
    }
}
