using FakeItEasy;

namespace ZeUnit.FakeItEasy;

public class FakeAttribute<TType, TAttribute>
    : ZeComposerAttribute<FakeClassComposer<TType, TAttribute>>
    , IFakeAttribute<TType>
    where TType : class
    where TAttribute : FakeAttribute<TType, TAttribute>
{
    public virtual Fake<TType> Create()
    {
        return new Fake<TType>();
    }

    protected virtual Fake<TType> Build(Fake<TType> fake)
    {
        return fake;
    }
}

public interface IFakeAttribute<TType>
    where TType : class
{
    Fake<TType> Create();
}
