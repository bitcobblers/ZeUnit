namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineDataAttribute : ZeBinderAttribute<InlineDataMethodComposer>
{
    public InlineDataAttribute(params object[] args)
    {
        Args = args;
    }

    public object[] Args { get; }
}