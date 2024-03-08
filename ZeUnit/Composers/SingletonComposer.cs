namespace ZeUnit.Composers;


public class SingletonComposer : ZeClassComposer<OnlyAttribute>
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
