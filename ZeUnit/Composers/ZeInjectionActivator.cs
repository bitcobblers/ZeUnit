
using System;

namespace ZeUnit.Composers;

public class SingletonAttribute : ZeComposerAttribute<SingletonComposer>
{
    public SingletonAttribute(Type @class) 
    {        
        this.Type = @class;     
    }

    public Type Type { get; }        
}

public static class ZeSingletonContainer
{
    public static Dictionary<Type, object> State { get; set; } = new Dictionary<Type, object>();
}

public class SingletonComposer : ZeClassComposer<SingletonAttribute>
{    
    public SingletonComposer(ZeComposerAttribute[] attributes) 
        : base(attributes)
    {
        var toAdd = this.Attributes
            .Where(a => !ZeSingletonContainer.State.ContainsKey(a.Type))
            .Select(a => (a.Type, Activator.CreateInstance(a.Type)!));

        foreach (var (key, value) in toAdd) 
        {
            ZeSingletonContainer.State.Add(key, value);
        }
    }

    public override object? Get(Type args) 
        => ZeSingletonContainer.State.ContainsKey(args)
            ? ZeSingletonContainer.State[args]
            : default;
    public void Dispose()
    {
    }
}
