using FakeItEasy;

namespace ZeUnit.FakeItEasy;

public class FakeClassComposer<TType> : IZeClassComposer
    where TType : class
{
    public object? Get(Type args)
    {
        var genericType = args.GetGenericArguments().FirstOrDefault();
        if (genericType != null && genericType == typeof(TType))
        {
            return new Fake<TType>();
        }
        return default;
    }
}
