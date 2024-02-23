
using System;

namespace ZeUnit.Composers;

public class SingletonAttribute : ZeComposerAttribute<SingletonComposer>
{
    public SingletonAttribute(Type @class) 
    {        
        this.Type = @class;     
    }

    public Type Type { get; }        
}
