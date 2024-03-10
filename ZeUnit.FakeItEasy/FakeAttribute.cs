using FakeItEasy;
using ZeUnit.Composers;

namespace ZeUnit.FakeItEasy;

public class FakeAttribute<TAttribute, TType>
     : ZeComposerAttribute<SingletonComposer<TAttribute>>
    , IZeBuilderAttribute    
    where TAttribute : FakeAttribute<TAttribute, TType>
    where TType : class
{
    public Type Type => typeof(Fake<TType>);

    public object Build()
    {
        return Build(Create());
    }

    public virtual Fake<TType> Create()
    {
        return new Fake<TType>();
    }

    protected virtual Fake<TType> Build(Fake<TType> fake)
    {
        return fake;
    }
}