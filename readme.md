### ZeUnit - simple unit testing with special sauce.

How do you define the size and scale of a Unit test.  At what point do you go from needed a simple unit testing framework to some type of integeration testing?  What if you didn't need to decide?  What if one testing framework could scale to handle the nitty-gritty low level unit testing, while also supporting the creation of large ingration tests that span the execution of whole components or event the system in its entierty. 

ZeUnit is here to help.  So some basics...

```
public class SampleZeTestClass
{
    public ZeResult SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return Ze.Assert()
            .IsType<int>(result)
            .IsEqual(4, result);
    }

    public ZeResult SimpleTestMethodThatFailes()
    {
        var result = 2 + 2;
        return Ze.Assert()            
            .IsEqual(5, result);
    }
}
```