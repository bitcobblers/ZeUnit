namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public ZeResult SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return Ze.Is
            .Type<int>(result)
            .Equal(4, result);
    }

    //public ZeResult SimpleTestMethodThatFailes()
    //{
    //    var result = 2 + 2;
    //    return Ze.Is            
    //        .Equal(5, result);
    //}
}