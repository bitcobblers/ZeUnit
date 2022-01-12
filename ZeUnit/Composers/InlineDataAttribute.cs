namespace ZeUnit.Composers;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineDataAttribute : ZeComposerAttribute
{
    public InlineDataAttribute(params object[] args)
        : base(typeof(InlineDataMethodComposer))
    {
        Args = args;
    }

    public object[] Args { get; }
}