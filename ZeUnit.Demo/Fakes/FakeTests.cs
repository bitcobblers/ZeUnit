using FakeItEasy;
using ZeUnit.FakeItEasy;

namespace ZeUnit.Demo.Fakes;

public class SystemUnderTest(IFakeService service)
{
    public int DoWork() => service.GetOne();
    public int DoWorkAdd(int value) => service.GetOne() + value;
}


public interface IFakeService
{
    int GetOne();
}

public class HappyPathFakeComposer : FakeAttribute<IFakeService, HappyPathFakeComposer>
{
    protected override Fake<IFakeService> Build(Fake<IFakeService> fake)
    {
        fake.CallsTo(x => x.GetOne())
            .Returns(1);
        return fake;
    }
}    

[HappyPathFakeComposer]
public class FakeTests(Fake<IFakeService> fake) 
{
    public Fact FakeIsReturnsTheValue()
    {
        var sut = new SystemUnderTest(fake.FakedObject);
        var result = sut.DoWork();
        return result == 1;
    }
}

public class ErrorPathFakeService : FakeAttribute<IFakeService, ErrorPathFakeService>
{
    protected override Fake<IFakeService> Build(Fake<IFakeService> fake)
    {
        fake.CallsTo(x => x.GetOne())
            .Throws(new Exception());
        return fake;
    }
}

[ErrorPathFakeService]
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