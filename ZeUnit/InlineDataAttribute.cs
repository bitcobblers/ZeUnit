namespace ZeUnit;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineDataAttribute : ZeActivatorAttribute
{
    public InlineDataAttribute(params object[] args) 
        : base(typeof(InlineMethodAttributeActivator))
    {
        this.Args = args;        
    }

    public object[] Args { get; }    
}