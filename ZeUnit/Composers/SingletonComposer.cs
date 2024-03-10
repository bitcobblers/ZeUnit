namespace ZeUnit.Composers;



public class SingletonComposer<TAttribute> : ZeClassComposer<TAttribute>
    where TAttribute : ZeComposerAttribute, IZeBuilderAttribute
{
    public SingletonComposer(ZeComposerAttribute[] attributes)
       : base(attributes)
    {
        var toAdd = this.Attributes
           .Where(a => !ZeSingletonContainer.State.ContainsKey(a.Type))
           .Select(a => (a.Type, a.Build()));

        foreach (var (key, value) in toAdd)
        {
            ZeSingletonContainer.State.Add(key, value);
        }
    }

    public override object? Get(Type args)
       => ZeSingletonContainer.State.ContainsKey(args)
           ? ZeSingletonContainer.State[args]
           : default;
}
