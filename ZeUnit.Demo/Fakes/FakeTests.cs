using FakeItEasy;
using ZeUnit.FakeItEasy;

namespace ZeUnit.Demo.Fakes
{
    public class SystemUnderTest(IFakeService service)
    {
        public int DoWork() => service.GetOne();
    }


    public interface IFakeService
    {
        int GetOne();
    }
    
    public class HappyPathComposer : FakeComposer<IFakeService>
    {
        protected override Fake<IFakeService> Compose(Fake<IFakeService> fake)
        {
            fake.CallsTo(x => x.GetOne())
                .Returns(1);
            return base.Compose(fake);
        }
    }    

    [Fake<IFakeService, HappyPathComposer>]
    public class FakeTests(Fake<IFakeService> fake) 
    {
        public Fact FakeIsReturnsTheValue()
        {
            var value = fake.FakedObject.GetOne();
            return  value == 1;
        }
    }

    public class ErrorPathComposer : FakeComposer<IFakeService>
    {
        protected override Fake<IFakeService> Compose(Fake<IFakeService> fake)
        {
            fake.CallsTo(x => x.GetOne())
                .Throws(new Exception());
            return base.Compose(fake);
        }
    }

    [Fake<IFakeService, ErrorPathComposer>]
    public class FakeTests2(Fake<IFakeService> fake)
    {
        public Fact FakeIsReturnsTheValue()
        {
            Action run = () => fake.FakedObject.GetOne();
            return run.Throws<Exception>();
        }
    }
}
