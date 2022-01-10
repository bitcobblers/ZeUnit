namespace ZeUnit;

[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
public class InlineDataAttribute : ZeActivatorAttribute
{
    public InlineDataAttribute(params object[] args)
    {
        this.Args = args;        
    }

    public object[] Args { get; }

    public override Type Activator => typeof(InlineAttributeActivator);
}