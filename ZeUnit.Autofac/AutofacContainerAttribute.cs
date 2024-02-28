using Autofac;

namespace ZeUnit.Autofac;
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AutofacContainerAttribute : ZeComposerAttribute<AutofacContainerClassComposer>
{
    public AutofacContainerAttribute() : this(typeof(Module))
    {
    }

    public AutofacContainerAttribute(Type registry) : base()
    {
        if (!registry.IsAssignableTo(typeof(Module)))
        {
            throw new InvalidDataException("Autofac container must register a type of Autofac.Module.");
        }

        Registry = registry;
    }

    public Type Registry { get; }
}