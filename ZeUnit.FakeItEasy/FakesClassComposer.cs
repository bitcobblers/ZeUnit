using FakeItEasy;

namespace ZeUnit.FakeItEasy;

public class FakesClassComposer : IZeClassComposer    
{
    protected Dictionary<Type, Func<object>> factory = new Dictionary<Type, Func<object>>();

    public object? Get(Type args)
    {
        var genericType = args.GetGenericArguments().FirstOrDefault();
        if (genericType == null || !args.FullName.StartsWith("FakeItEasy.Fake"))
        {
            return default;
        }
        if (!factory.ContainsKey(genericType)) 
        {
            Type fakeType = typeof(Fake<>).MakeGenericType(new Type[] { genericType });
            factory.Add(genericType, () => Activator.CreateInstance(fakeType)!);            
        }        

        return factory[genericType]();
    }    
}
