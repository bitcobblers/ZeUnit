// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit;

public class ComposerClassFactory 
    // : BaseComposerFactory<IZeClassComposer, CoreClassComposer>
{
    public IEnumerable<IZeClassComposer> Get(Type type)
    {
        var attributes = type.GetCustomAttributes();

        var activatorGroups = attributes
           .Where(n => n.GetType().IsAssignableTo(typeof(ZeInjectorAttribute)))
           .Select(n => (ZeInjectorAttribute)n)
           .GroupBy(n => n.Activator, n => n);

        if (!activatorGroups.Any())
        {
            yield return new CoreClassComposer(type);
            yield break;
        }

        foreach (var group in activatorGroups)
        {
            var activator = group.Key;
            var constructor = activator
                .GetConstructors()
                .OrderBy(n => n.GetParameters().Length)
                .First();

            var args = constructor.GetParameters();



            if (args.Length == 0)
            {
                yield return (IZeClassComposer)constructor.Invoke(null);
                continue;
            }

            if (args.Length == 1 && typeof(IEnumerable).IsAssignableFrom(args.First().ParameterType))
            {
                yield return (IZeClassComposer)constructor.Invoke(new[] { group.ToArray() });
                continue;
            }

            if (args.Length == 1 && typeof(ZeComposerAttribute) == args.First().ParameterType)
            {
                foreach (var attribute in group)
                {
                    yield return (IZeClassComposer)constructor.Invoke(new object[] { attribute });
                }

                continue;
            }

            throw new ArgumentException("Could not create activator, constructor must be empty, take a single ZeActivatorAttribute or a IEnumerable<ZeActivationAttribute> to be valid.");
        }
    }
}
