The `SampleZeUnitClass` test in the previous [section](https://bitcobblers.github.io/ZeUnit/docs/Quick-Start-Guide.html), was the coal mine canary to make sure the testing framework is discovering and executing tests.  In this section, we are take a look at how ZeUnit makes "real world" testing easier as we tackle testing our extensible calculator class. 

### Lesson Plan:
- look over some basic unit tests against the addition operation.
- show case the benefits of using method activation to reduce the amount of repeating test code.
- scale our test to integration level by leveraging custom class activation.


The calculator code being tested here can be found here: [/ZeUnit.Demo/DemoCalculator](https://github.com/bitcobblers/ZeUnit/tree/master/ZeUnit.Demo/DemoCalculator). 

## Different, but Kind of the Same
We are hardy SOLID programmers, and as a result we can focus on a single responsibility at a time.  Lets take a closer look at what it means to add different number of arguments on the calculator.  The tests bellow are written in a format that should feel familiar to developers already doing testing in dotnet.  What is noticeably different here from the existing frameworks is that tests return a results, which is analogous to a call against the Assert class in traditional unit testing frameworks. 

```csharp
        public Ze PassingNullValueWillResultInZero()
        {
            var addition = new AddOperation();
            var actual = addition.Apply(0, null).Value;
            return actual.Is(0);
        }

        public Ze PassingSingleValueResultWithTheValue()
        {
            var addition = new AddOperation();
            var actual = addition.Apply(0, new[] { 1d }).Value;
            return actual.Is(1d);
        }

        public Ze PassingTwoValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            var actual = addition.Apply(0, new[] { 1d, 2d }).Value;
            return actual.Is(3d);
        }

        public Ze PassingManyValuesResultWithTheSum()
        {
            var addition = new AddOperation();
            var actual = addition.Apply(0, new[] { 1d, 2d, 3d, 4d }).Value;
            return actual.Is(10d);
        }
```

## Getting Some Reusability
The code above is verbose, and "I pity the fool" who has to deal with all the code changes when the `Apply` method signature changes or a large number of additional similar tests need to be created. And really the only difference between the individual tests above is the data inputs and expectations.  So let's what we get when we sprinkle some ZeUnit magic on the code above.

```csharp
    public class TestingAdditionInlineData
    {
        [InlineData(null, 0)]
        [InlineData(new[] { 1d }, 1)]
        [InlineData(new[] { 1d, 2d }, 3)]
        [InlineData(new[] { 1d, 2d, 3d, 4d }, 10)]
        public Ze AdditionHarness(double[] values, double expected)
        {
            var addition = new AddOperation();
            var actual = addition.Apply(0,values).Value;
            return actual.Is(expected);
        }
    }
```
The instances of the `InlineData` attributes each represent a single entry/test in this test class.  We have a repeating code harness and we run different scenarios though it saving us much code and making adding additional similar data tests a beaze.

`InlineData` method attribute is inspired by the `Theory` attribute from XUnit. However, in the ZeUnit universe, test method attributes of type `ZeComposerAttribute` represent an entire class of method composers that super charge the developers ability to consume test data.  ZeUnit comes stocked with some common method activators like the `InlineData` attribute.  See [Existing Method Composition](https://bitcobblers.github.io/ZeUnit/docs/Existing-Method-Composition.html) & [Custom Method Composition](https://bitcobblers.github.io/ZeUnit/docs/Custom-Method-Composition.html).

## Putting it all Together
Assuming all the `ICalculatorOperation` are well tested, can we be sure that everything works?  Well not really, because while we have tested all the operations, we haven't really created any tests against the calculator itself.   Sure, unit testing the mechanics of the apply function on the calculator class is a must, but those shouldn't depend on any specific instances of `ICalculatorOperation`.  There is also the bootstrapping of the calculator at load time.  We have the ability to register any number of `ICalculatorOperation` with an instance of the calculator.  Testing defaults or custom modules for example would also add value and bring up the developer confidence level.

Lets take a look at what that looks like with ZeUnit.

```csharp
    [LamarContainer(typeof(CalculatorRegistry))]
    public class TestingCalculatorIntegration
    {
        private readonly ICalculator calculator;

        public TestingCalculatorIntegration(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        [InlineData(null, 0)]
        [InlineData(new[] { 1d }, 1)]
        [InlineData(new[] { 1d, 2d }, 3)]
        [InlineData(new[] { 1d, 2d, 3d, 4d }, 10)]
        public Ze AdditionHarness(double[] values, double expected)
        {            
            var actual = this.calculator.Apply<AddOperation>(values).Value.Value;
            return actual.Is(expected);
        }

    }
```