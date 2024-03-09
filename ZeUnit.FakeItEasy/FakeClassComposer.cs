using FakeItEasy;
using ZeUnit.Composers;

namespace ZeUnit.FakeItEasy;

public class FakeClassComposer<TType, TAttribute> 
    : ZeClassComposer<TAttribute>   
    where TType : class
    where TAttribute : FakeAttribute<TType, TAttribute>
{
    private readonly IFakeAttribute<TType>? composer;

    public FakeClassComposer(ZeComposerAttribute attributes) 
        : base(attributes)
    {        
    }

    public override object? Get(Type args)
    {
        var genericType = args.GetGenericArguments().FirstOrDefault();
        if (genericType != null && genericType == typeof(TType))
        {
            return composer?.Create();
        }
        return default;
    }
}
