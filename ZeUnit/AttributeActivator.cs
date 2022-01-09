// See https://aka.ms/new-console-template for more information
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

    protected override ZeResult Run(object instance, MethodInfo method, IEnumerable<ZeActivatorAttribute> attributes)
    {
        return this.Run(instance, method, attributes.Select(n => (TAttribute)n));
    }

    protected abstract ZeResult Run(object instance, MethodInfo method, IEnumerable<TAttribute> attributes);
}

public abstract class AttributeActivator : IZeTestActivator
{
    private List<Type> types = new List<Type>();

    protected void Register<TType>()
        where TType : ZeActivatorAttribute
    {
        this.types.Add(typeof(TType));
    }

    public object Get(TypeInfo @class)
    {
        var attributes = @class.GetCustomAttributes()
            .Where(n=>this.types.Contains(n.GetType()))
            .Select(n=>(ZeActivatorAttribute)n);

        return this.Get(@class, attributes);
    }

    protected abstract object Get(TypeInfo @class, IEnumerable<ZeActivatorAttribute> attributes);
    
    public ZeResult Run(object instance, MethodInfo method)
    {
        var attributes = method.GetCustomAttributes()
            .Where(n => this.types.Contains(n.GetType()))
            .Select(n => (ZeActivatorAttribute)n);

        return this.Run(instance, method, attributes);
    }

    protected abstract ZeResult Run(object instance, MethodInfo method, IEnumerable<ZeActivatorAttribute> attributes);

    public void Dispose()
    {        
    }    
}
