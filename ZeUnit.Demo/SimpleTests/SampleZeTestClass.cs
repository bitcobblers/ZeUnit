namespace ZeUnit.Demo.SimpleTests;

public class SampleZeTestClass
{
    public Ze SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return result
            .Is(4)
            .IsType<int>();
    }    

    public Ze UsingInplicitCasting() 
    {            
        var result = 2 + 2;
        return result == 4;
    }    

    
    public Ze UsingInplicitCastingCustomMessage() 
    {            
        var result = 2 + 2;
        return (result == 4, "2 + 2 should be 4");
    }    
}