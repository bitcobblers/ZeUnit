namespace ZeUnit;

public class TransientAttribute : ZeLifeCycleAttribute
{
    public override ZeClassInstanceFactory GetFactory(IZeClassComposer composer, TypeInfo type)
    {
        return new TransientInstanceFactory(composer, type);
    }
    public class TransientInstanceFactory : ZeClassInstanceFactory
    {
        private readonly IZeClassComposer composer;
        private readonly TypeInfo type;

        public TransientInstanceFactory(IZeClassComposer composer, TypeInfo type)
        {
            this.composer = composer;
            this.type = type;
        }

        public override object Create()
        {
            return composer.Get(this.type);
        }
    }
}
