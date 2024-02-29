using FakeItEasy;

namespace ZeUnit.FakeItEasy;

public class FakeComposer<TType> : IFakeComposer<TType>
     where TType : class
{
    public virtual Fake<TType> Create()
    {
        return Compose(new Fake<TType>());
    }

    protected virtual Fake<TType> Compose(Fake<TType> fake)
    {
        return fake;
    }
}

public interface IFakeComposer<TType>
where TType : class
{

    Fake<TType> Create();
}

public class FakeClassComposer<TType, TComposer> : IZeClassComposer
    where TComposer : IFakeComposer<TType>, new()
    where TType : class
{
    public object? Get(Type args)
    {
        var genericType = args.GetGenericArguments().FirstOrDefault();
        if (genericType != null && genericType == typeof(TType))
        {
            return new TComposer().Create();            
        }
        return default;
    }
}

public class FakeClassComposer<TType> : FakeClassComposer<TType, FakeComposer<TType>>
    where TType : class
{
}
