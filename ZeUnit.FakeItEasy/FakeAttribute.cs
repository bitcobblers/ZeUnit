using FakeItEasy;

namespace ZeUnit.FakeItEasy;

public class FakeAttribute<TType>
    : ZeComposerAttribute<FakeClassComposer<TType>>
    , IFakeComposer<TType>
    where TType : class
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

public interface IFakeComposer<TType>
    where TType : class
{
    Fake<TType> Create();
}
