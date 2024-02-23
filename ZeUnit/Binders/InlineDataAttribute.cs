﻿namespace ZeUnit.Binders;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class InlineDataAttribute : ZeComposerAttribute<InlineDataMethodComposer>
{
    public InlineDataAttribute(params object[] args) : base()
    {
        Args = args;
    }

    public object[] Args { get; }
}