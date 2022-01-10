namespace ZeUnit;

public abstract class AttributeActivator<TAttribute> : AttributeActivator
    where TAttribute : ZeActivatorAttribute
{
    protected AttributeActivator()
    {
        this.Register<TAttribute>();
    }

    protected override object Get(TypeInfo @class, IEnumerable<ZeActivatorAttribute> attributes)
    {
        return this.Get(@class, attributes.Select(n => (TAttribute)n));
    }

    protected abstract object Get(TypeInfo @class, IEnumerable<TAttribute> attributes);

    protected override IEnumerable<object[]> Get(MethodInfo method, IEnumerable<ZeActivatorAttribute> attributes)
    {
        return this.Get(method, attributes.Select(n => (TAttribute)n));
    }

    protected abstract IEnumerable<object[]> Get(MethodInfo method, IEnumerable<TAttribute> attributes);
}