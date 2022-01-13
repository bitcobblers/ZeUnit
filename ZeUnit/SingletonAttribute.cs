namespace ZeUnit;

public class SingletonAttribute : ZeLifeCycleAttribute
{
    public override ZeClassInstanceFactory Create(IZeClassComposer composer, TypeInfo type)
    {
        return new SingletonInstanceFactory(composer, type);
    }

    public class SingletonInstanceFactory : ZeClassInstanceFactory
    {
        private readonly object instance;        

        public SingletonInstanceFactory(IZeClassComposer composer, TypeInfo type)
        {
            this.instance = composer.Get(type);            
        }

        public override object Create()
        {
            return instance;
        }
    }
}
