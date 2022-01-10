// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

public static class MethodActivatorFactory
{
    public static IEnumerable<IZeActivator> Get(MethodInfo method)
    {
        var activators = method.GetCustomAttributes()
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeActivatorAttribute)))
            .Select(n => (ZeActivatorAttribute)n)
            .Select(n => n.Activator)
            .Select(n => (IZeActivator)Activator.CreateInstance(n));

        return activators.Any()
            ? activators
            : new[] { new CoreTestActivator() };
    }
}
