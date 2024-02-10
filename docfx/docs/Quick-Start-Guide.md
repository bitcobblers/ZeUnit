ZeUnit is an all purpose testing framework designed to scale from the small scale of unit tests to integration and behavior tests that stand up the whole system.  In this section we will look at the steps needed to start working with ZeUnit.

## Lesson Plan
- Include the necessary NuGet packages for ZeUnit to run in a test project
- Get some tests to execute in visual studio
- Identify the key difference between ZeUnit and other testing frameworks.

Like any unit testing framework, the testing project will need to include the ZeUnit NuGet packages as well as the ZeUnit.TestAdapter and Microsft.NET.Test.Sdk to enable running the tests inside visual studio.  Open up the NuGet package manager console and run the following commands in the context of your test project.

```
Install-Package ZeUnit
Install-Package ZeUnit.TestAdapter
Install-Package Microsoft.NET.Test.Sdk
```

Paste the `SimpleZeUnitClass` to replace implemntation in `Class1.cs` file that is automatically created for you by visual studio.

```csharp
public class SampleZeUnitClass
{
    public Ze SimpleTestMethodThatPasses() 
    {            
        var result = 2 + 2;
        return result
            .Is(4)            
            .IsType<int>();
    }

    public async Task<Ze> SimpleAsyncTestMethodThatFails()
    {
        var result = 2 + 2;
        return result.Is(5);            
    }
}
```

Open up the Test Explorer window in Visual studio, and kick off the tests.  It will display a passing and failing result for the two test we created above.

## Functional Approach to Tests

Developers familiar with existing testing frameworks like XUnit and NUnit will notices some key differences.
 - The familiar `Assert` has been replaced by `new ZeResult()` or a collection of shouldly style assertion helpers.  
 - Test methods return `ZeResult` in the case of single synchronous test result and `Task<ZeResult>` when the single result is asynchronous. 

ZeUnit brows a lot from functional programing, and requires that functions return results. In our case the `ZeResult` object which can have 0 or more assertions like `Equal` or `Type` in the code example above.   Labeling the test function with resulting type as defined in the table bellow allows you to expressly define the execution timeline of your test(s) and how the `ZeResult` object(s) is/are being returned.

|  Test Results   | **One**          |  **Many**               |
| --------------- | ---------------- | ----------------------- |
| **Now**         | `ZeResult`       | `IEnumerable<ZeResult>` |
| **Later**       | `Task<ZeResult>` | `IObservable<ZeResult>` |


***

Next Section: [Testing A Calculator](https://bitcobblers.github.io/ZeUnit/docs/Testing-A-Calculator.html)