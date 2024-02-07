---
_layout: landing
---

# ZeUnit Testing Framework

At the heart of ZeUnit sits a simple principle, functional programing is cleaner.  
- Tests should be functions.
- Functions should have all the necessary dependencies.
- Functions should return a consistent results

Taking this "pure" function approach to testing allows some interesting windfall effects that can super charge your testing experience.

- Custom test activation
- Different class life-cycles
- Test middleware

## Traditional Test

```csharp
[Fact]
public void WhatYouTest()
{
    // Act
    var actual = someWork();
    // Assert
    Assert.Equal(actual, "expected");
}
```

## ZeUnit Test

At the heart a test is binary, it passes or fails, so giving a `bool` as a response will be implicity converted to a `ZeResult` as good stratagy for coders that use descriptive unit tests names.

```csharp
public ZeResult WhatYouTestSimpleAssertion()
{
    // Act
    var actual = someWork();
    // Assert
    return actual == "expected";
}
```

Optionally, the more expressive Shouldly inspired assertion syntax can be used to create instance of `ZeResult` with additional message feedback and knowledge about the values and the assertion being made.  The example bellow would generate automated message to show the difference between the outcomes, while the example above would flag the test as pass or fail.

```csharp
public ZeResult WhatYouTestBetterAssertion()
{
    // Act
    var actual = someWork();
    // Assert
    return actual.Is("expected");
}

Dig in..

```
### ZeUnit Basics
* [Quick Start Guide](https://bitcobblers.github.io/ZeUnit/docs/Quick-Start-Guide.html):

* [Testing a Calculator](https://bitcobblers.github.io/ZeUnit/docs/Testing-A-Calculator.html)
* [Existing Method Composition](https://bitcobblers.github.io/ZeUnit/docs/Existing-Method-Composition.html)

* [Integration Testing and Test Lifecycles](https://bitcobblers.github.io/ZeUnit/docs/Integration-Testing-and-Test-Lifecycles.html)
* [Integration Testing and Report Generation](https://bitcobblers.github.io/ZeUnit/docs/Integration-Testing-and-Report-Generation.html)
* [Existing Report Writers](https://bitcobblers.github.io/ZeUnit/docs/Existing-Report-Writers.html)

### ZeUnit Modules
* [Lamar Dependency Injection](https://bitcobblers.github.io/ZeUnit/docs/Lamar-Dependency-Injection.html)

### ZeUnit Customization 
* [Don't Just Use, Make it Your Own](https://bitcobblers.github.io/ZeUnit/docs/Dont-Just-Use-Make-it-Your-Own.html)

* [Custom Method Composition](https://bitcobblers.github.io/ZeUnit/docs/Custom-Method-Composition.html)
* [Custom Class Composition](https://bitcobblers.github.io/ZeUnit/docs/Custom-Class-Composition.html)
* [Custom Report Writers](https://bitcobblers.github.io/ZeUnit/docs/Custom-Report-Writers.html)
