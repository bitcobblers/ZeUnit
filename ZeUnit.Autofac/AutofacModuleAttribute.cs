using Autofac;

namespace ZeUnit.Autofac;
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AutofacModuleAttribute<TModule> : AutofacModuleAttribute
    where TModule : Module
{
    public AutofacModuleAttribute() : base(typeof(TModule))
    {
    }
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AutofacModuleAttribute : ZeComposerAttribute<AutofacContainerClassComposer>
{
    public AutofacModuleAttribute() : this(typeof(Module))
    {
    }

    public AutofacModuleAttribute(Type registry) : base()
    {
        if (!registry.IsAssignableTo(typeof(Module)))
        {
            throw new InvalidDataException("Autofac container must register a type of Autofac.Module.");
        }

        Registry = registry;
    }

    public Type Registry { get; }
}