using FakeItEasy;
using ZeUnit.FakeItEasy;

namespace ZeUnit.Demo.Fakes
{
    public class SystemUnderTest(IFakeService service)
    {
        public int DoWork() => service.GetOne();
        public int DoWorkAdd(int value) => service.GetOne() + value;
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
            var sut = new SystemUnderTest(fake.FakedObject);
            var result = sut.DoWork();
            return result == 1;
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
            var sut = new SystemUnderTest(fake.FakedObject);
            return Is<Exception>.Thrown(() => sut.DoWork());            
        }

        public Fact FakeIsReturnsTheValueWithArg1()
        {
            var sut = new SystemUnderTest(fake.FakedObject);
            return Is<Exception>.Thrown(sut.DoWorkAdd, 1);
        }

        public Fact FakeIsReturnsTheValueWithArg2()
        {
            var sut = new SystemUnderTest(fake.FakedObject);
            return Is<Exception>.Thrown(() => sut.DoWorkAdd(1));
        }


    }
}