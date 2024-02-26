# Method Binders 

Method composition is the mechanism for injecting test data into your tests.  In the previous section [Testing A Calculator](/docs/Testing-A-Calculator.html), we saw `InlineData` attributes being used to push data into a single test method.  While this is useful in many unit tests scenarios, scaling this to integration testing becomes tedious, especially with the dotnet limitations on primitive types as arguments for Attributes.  To bridge the gap into integration testing ZeUnit comes equipped with tools to help you work with test data.

This is a common trend of integration frameworks, the idea of a detached data state that doesn't require the test code to be modified for additional test cases to run.

- Fitness: Wiki files and commonly xml/json data files the wikis point to.
- SpecFlow: Cucumber and again points to a file.
- ZeUnit takes a more holistic approach and allows method composer to consume files directly for test execution.  

## Binding To Files

In the example below, we can see the same test.txt file being loading with each test method.  The key difference is the argument type allowing to pull in the file as low level or high level as is necessary:

- Stream
- byte[]
- string

```csharp
public class FileInjectionTests
{
    [LoadFile("FileTests/test.txt")]
    public Fact LoadFileStream(FileStream stream)
    {
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd().Is("test");
    }

    [LoadFile("FileTests/test.txt")]
    public Fact LoadFileText(string actual)
    {            
        return actual.Is("test");
    }

    [LoadFile("FileTests/test.txt")]
    public Fact LoadFileByteArray(byte[] actual)
    {        
        var expected = Encoding.ASCII.GetBytes("test");            
        // skip(3) ignores the BOM (EF BB BF in hex)
        var actual = expected.SequenceEqual(actual.Skip(3));
        return actual.True();
    }
}
```

## Developer Integration Testing

While loading raw files is some time useful, chances are the test data being loaded represent some serializable type, so additionally json and xml files can be targeted to any POCO class and the binding will attempt to deserialize the type.  Serializable types are especially useful when dealing with common starting scenarios that can be reused across a wide range of tests.

```csharp
public class DeserializeTests
{
    [LoadFile("FileTests/test.xml")]
    public Fact LoadFileSerializedXMLObject(SerializedType actual)
    {
        return actual.Text.Is("test");
    }

    [LoadFile("FileTests/test.json")]
    public Fact LoadFileSerializedJsonObject(SerializedType actual)
    {
        return actual.Text.Is("test");
    }
}

```

## Taking it Full Scale

The examples so far still fail to meet the needs of integrations testing at scale because the files being used are always hard coded with in the assembly.  This means, only developers could make changes there and meaning that SMEs still need developer engagement for creating additional testing.  As mentioned earlier, method composition can result in 1 or more tests being run, so the natural progression from a `LoadFile` would the `LoadFiles` which reads over a directory and creates a test for each file found.

```csharp
    public class DirectoryInjectionTests
    {
        [LoadFiles("FileTests/test/")]
        public Fact LoadedFromDirectory(string fileString)
        {
            return fileString.IsNotEmpty();
        }

        [LoadFiles("FileTests/test/")]
        public Fact LoadedFromDirectoryWithExtension(
            [ExtensionFilter(".sample.txt")] string fileString)
        {
            return fileString.IsNotEmpty();
        }
    }
```

To avoid indiscriminately grabbing all the files in a directory, the `LoadFiles` method composer is able to process additional information from the `ExtensionFilter` attribute on method parameters.  Adding this attribute to the code will only pick up on file with names ending in the defined extension.

ZeUnit steps this up one more notch with the introduction of the `LoadFileGroups` method composer that is able to group files together by name and populate multiple method parameters based on matching filters.  Grouping data sets into multiple files like the test data and the expected result files like the example below empowers the recruitment of business SMEs to generate better tests data and having stronger confidence in the system.

```csharp
   public class DirectoryFileSetsInejctionTests 
    { 
        [LoadFileGroups("FileTests/test/")]
        public Fact LoadedFromDirectoryWithMultipleExtension(
            [ExtensionFilter(".test.txt")]string test, 
            [ExtensionFilter(".result.txt")]string result)
        {
            return test.Is(result);
        }
    }
```

The method composition system is open to be extension by writing additional method composers.  More information about building custom method composers can be found in here: [Custom Method Composition](/docs/Custom-Method-Composition.html)

***
Next Section [Class Composition](/docs/core-class-composers)
