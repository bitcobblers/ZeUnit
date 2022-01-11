// See https://aka.ms/new-console-template for more information

namespace ZeUnit.Activators;

public abstract class ActivatorFactory<TInterface, TDefault>    
    where TDefault : TInterface, new()
{
    public IEnumerable<TInterface> Get(Type type)
    {
        return this.Get(type.GetCustomAttributes()
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeActivatorAttribute)))
            .Select(n => (ZeActivatorAttribute)n));
    }

    public IEnumerable<TInterface> Get(MethodInfo method)
    {
        return this.Get(method.GetCustomAttributes()
            .Where(n => n.GetType().IsAssignableTo(typeof(ZeActivatorAttribute)))
            .Select(n => (ZeActivatorAttribute)n));
    }

    public IEnumerable<TInterface> Get(IEnumerable<ZeActivatorAttribute> attributes)
    {
        var activatorGroups = attributes 
            .GroupBy(n => n.Activator, n => n);

        if (!activatorGroups.Any())
        {
            yield return new TDefault();
            yield break;
        }

        foreach (var group in activatorGroups)
        {
            var activator = group.Key;                                                   
            var constructor = activator
                .GetConstructors()                    
                .First();

            var args = constructor.GetParameters();
            if (args.Length == 0)
            {
                yield return (TInterface)constructor.Invoke(null);
                continue;
            }
            
            if (args.Length == 1 && typeof(IEnumerable).IsAssignableFrom(args.First().ParameterType))
            {
                var value = group.Select(n=>(ZeActivatorAttribute)n).ToArray();
                yield return (TInterface)constructor.Invoke(new[] { value });
                continue;
            }

            if (args.Length == 1 && args.First().ParameterType == typeof(ZeActivatorAttribute))
            {                
                foreach (var attribute in group) 
                {
                    yield return (TInterface)constructor.Invoke(new object[] { attribute });
                }

                continue;
            }

            throw new ArgumentException("Could not create activator, constructor must be empty, take a single ZeActivatorAttribute or a IEnumerable<ZeActivationAttribute> to be valid.");
        }                    
    }
}
