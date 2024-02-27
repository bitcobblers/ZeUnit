using FakeItEasy;
using ZeUnit.FakeItEasy;

namespace ZeUnit.Demo.Fakes
{
    public interface IFakeService
    {
        int GetOne();
    }

    [Fake<IFakeService>]
    public class FakeTests(Fake<IFakeService> fake) 
    {       
        public Fact FakeIsReturnsTheValue()
        {
            fake.CallsTo(x => x.GetOne())
                .Returns(1);

            return fake.FakedObject.GetOne() == 1;
        }
    }
}
