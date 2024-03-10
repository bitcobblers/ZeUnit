using Microsoft.Extensions.FileProviders;
using ZeUnit.CodeView;

namespace ZeUnit.Demo.EnumerableTests;

public class EnumerableTests
{
    public IEnumerable<Fact> EnumerableTestRun()
    {
        return Enumerable.Range(1, 5).Select(i => i.Is(i));
    }    
}

public class CodeReaderTests
{
    public Fact CanReadFile()
    {
        var provider = new PhysicalFileProvider("C:\\dev\\ZeUnit\\ZeUnit\\CodeView\\");
        var file = provider.GetFileInfo("FileIndex.cs");

        var parser = new FileIndexParser();
        return !parser.ReadTest(file).Any();

    }

    public Fact CanReadFacts()
    {
        var provider = new PhysicalFileProvider("C:\\dev\\ZeUnit\\ZeUnit.Demo\\EnumerableTests\\");
        var file = provider.GetFileInfo("EnumerableTests.cs");

        var parser = new FileIndexParser();
        var result = parser.ReadTest(file).ToArray();
        return result.Any();

    }

    public Fact CanFindSolution()
    {
        var provider = new ZeCodeSolutionProvider();
        var result = provider.Code();
        return result.Any();

    }
}
