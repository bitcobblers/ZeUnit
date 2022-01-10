namespace ZeUnit.Reporters;

public class HtmlFileReporter : IZeReporter
{

    public void Report(ZeTest test, IEnumerable<ZeResult> result)
    {
        Console.WriteLine("new html file?");
    }
}