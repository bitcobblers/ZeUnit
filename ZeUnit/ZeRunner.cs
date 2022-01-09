// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public static class ClassActivatorFactory
{
    public static IZeTestActivator Get(TypeInfo @class)
    {
        var activators = @class.GetCustomAttributes()
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeActivatorAttribute)))
            .Select(n => (ZeActivatorAttribute)n)
            .Select(n => n.Activator)
            .Distinct();

        switch (activators.Count())
        {
            case 0:
                return new CoreTestActivator();
            case 1:
                return (IZeTestActivator)Activator.CreateInstance(activators.First());
            default:
                break;
        }

        throw new Exception("Could not create insatnce of class, defining mulitple activator types on a single class is not supported.");
    }
}

public static class MethodActivatorFactory
{
    public static IEnumerable<IZeTestActivator> Get(MethodInfo method)
    {
        var activators = method.GetCustomAttributes()
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeActivatorAttribute)))
            .Select(n => (ZeActivatorAttribute)n)
            .Select(n => n.Activator)
            .Select(n => (IZeTestActivator)Activator.CreateInstance(n));

        return activators.Any()
            ? activators
            : new[] { new CoreTestActivator() };
    }
}


public class ZeRunner : IZeRunner
{
    public IEnumerable<ZeResult> Run(ZeTest test)
    {
        using var activator = ClassActivatorFactory.Get(test.Class);
        var instance = activator.Get(test.Class);
        foreach (var methodActivator in MethodActivatorFactory.Get(test.Method))
        {
            var result = Ze.Assert();
            try
            {
                result = methodActivator.Run(instance, test.Method);
            }
            catch (Exception ex)
            {
                result.Assert(new Failed(ex.Message));
            }

            yield return result;
        }
    }
}