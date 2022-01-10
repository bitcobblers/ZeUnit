// See https://aka.ms/new-console-template for more information
namespace ZeUnit;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class InlineDataAttribute : ZeActivatorAttribute
{
    public InlineDataAttribute(params object[] args)
    {
        this.Args = args;
        this.WithActivator<InlineAttributeActivator>();
        
    }

    public object[] Args { get; }
}

public class InlineAttributeActivator : AttributeActivator<InlineDataAttribute>
{
    protected override object Get(TypeInfo @class, IEnumerable<InlineDataAttribute> attributes)
    {
        var args = attributes.SelectMany(n=>n.Args).ToArray();
        return @class.GetConstructor(args.Select(n => n.GetType()).ToArray()).Invoke(args);
    }

    protected override IEnumerable<object[]> Get(MethodInfo method, IEnumerable<InlineDataAttribute> attributes)
    {
        return attributes.Select(n => n.Args).ToArray();        
    }    
}
