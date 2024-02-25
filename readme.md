### ZeUnit 

- [Quick Start Guide](https://zeunit.org/docs/getting-started/)
- [Documentation](https://zeunit.org/)

## Why ZeUnit
XUnit and NUnit are both battle hardened frameworks that are running countless tests in the wild.  Our tools and work seamlessly with the existing frameworks that is seems like dark wizadry not worthy to mess around with.  

[How Google Tests Software](https://amzn.to/3G4e4V4) talks about a system of test classification that doesn't neatly fit into the bucket of unit or integration testing and instead classifies them as small, medium or large.  But the duality of testing frameworks seem to push you into a binary choice. 

* **Unit Testing** - in dotnet, this would be XUnit or NUnit, both of which focus on small scale testing and don't come with tools that enable contextual state.  The dogma that comes with using these framework chastises the use of classes that set up state, preaching a pure test instantiating all of it's scope.
* **Integration Testing** - these would be your SpecFlow, Fitnesse and StoryTeller.  At the abstract layer, these frameworks enable some kind of system state abstracted behind a fixture.  But with the tendency of these languages to use runtime test interpreters, writing low level integration tests is not really practical.

ZeUnit aims to fit as a bridge between these two worlds, allowing developer centric unit and integration testing to be written with one framework and with out the necessary ceremony of creating complicated wiki file bindings.  To support the wide range of test sizes ZeUnit allows the overriding the class and method activations allowing developers to inject state and tests data. 

## What gives ZeUnit its power?

ZeUnit was conceived as am idea for preloading state into XUnit because when a colleague asked for an Integration Testing framework recommendation, I couldn't give him one.  This led me down a rabbit hole of looking at XUnit code, and after some thinking I had an answer to my integration testing framework.  What if we give Test classes dependency injection?

Several iterations later, this has turned into a framework that supports a testing based set of custom class and method composer, that allow context to be created for the execution of a tests.

