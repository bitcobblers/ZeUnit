// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Binders;

public abstract class BaseComposerFactory<TDefault>
    where TDefault : IZeMethodBinder
{
    public abstract TDefault Create(Type defaultType);

    protected IEnumerable<IZeMethodBinder> Get(IEnumerable<Attribute> attributes)
    {
        var activatorGroups = attributes
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeComposerAttribute)))
            .Select(n => (ZeComposerAttribute)n)
            .GroupBy(n => n.Activator, n => n);

        if (!activatorGroups.Any())
        {
            yield return Create(typeof(TDefault));
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
                yield return (IZeMethodBinder)constructor.Invoke(null);
                continue;
            }

            if (args.Length == 1 && typeof(IEnumerable).IsAssignableFrom(args.First().ParameterType))
            {
                yield return (IZeMethodBinder)constructor.Invoke(new[] { group.ToArray() });
                continue;
            }

            if (args.Length == 1 && typeof(ZeComposerAttribute) == args.First().ParameterType)
            {
                foreach (var attribute in group)
                {
                    yield return (IZeMethodBinder)constructor.Invoke(new object[] { attribute });
                }

                continue;
            }

            throw new ArgumentException("Could not create activator, constructor must be empty, take a single ZeActivatorAttribute or a IEnumerable<ZeActivationAttribute> to be valid.");
        }
    }
}
