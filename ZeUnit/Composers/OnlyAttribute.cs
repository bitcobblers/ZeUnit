namespace ZeUnit.Composers;

public class OnlyAttribute : ZeComposerAttribute<SingletonComposer>
{
    public OnlyAttribute(Type @class) 
    {        
        this.Type = @class;     
    }

    public Type Type { get; }        
}
