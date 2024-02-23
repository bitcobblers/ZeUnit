// See https://aka.ms/new-console-template for more information

using ZeUnit.Composers;

namespace ZeUnit;

public class ComposerClassFactory : List<IZeClassComposer>
{ 
    public ComposerClassFactory(Type @class)
    {
        var attributes = @class.GetCustomAttributes();

        var activatorGroups = attributes
           .Where(n => n.GetType().IsAssignableTo(typeof(ZeComposerAttribute)))
           .Select(n => (ZeComposerAttribute)n)
           .GroupBy(n => n.Activator, n => n);

        if (!activatorGroups.Any())
        {
            return;
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
                Add((IZeClassComposer)constructor.Invoke(null));
                continue;
            }

            if (args.Length == 1 && typeof(IEnumerable).IsAssignableFrom(args.First().ParameterType))
            {
                Add((IZeClassComposer)constructor.Invoke(new[] { group.ToArray() }));
                continue;
            }

            if (args.Length == 1 && typeof(ZeBinderAttribute) == args.First().ParameterType)
            {
                foreach (var attribute in group)
                {
                    Add((IZeClassComposer)constructor.Invoke(new object[] { attribute }));
                }

                continue;
            }

            throw new ArgumentException("Could not create activator, constructor must be empty, take a single ZeActivatorAttribute or a IEnumerable<ZeActivationAttribute> to be valid.");
        }
    }

    public object? Get(ParameterInfo arg) => this
        .Select(n => n.Get(arg.ParameterType))
        .FirstOrDefault(n=>n != null);

}
