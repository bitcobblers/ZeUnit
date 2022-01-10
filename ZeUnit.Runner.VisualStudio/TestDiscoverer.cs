namespace ZeUnit.Runner.VisualStudio;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.Reflection;

[FileExtension(".dll")]
[FileExtension(".exe")]
[DefaultExecutorUri(Constants.ExecutorUri)]
public class TestDiscoverer : ITestDiscoverer
{
    public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
    {
        Console.WriteLine("ERROR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        logger.SendMessage(TestMessageLevel.Error, $"Starting ZeTest Discovery: {string.Join(", ", sources)}");
        foreach (var source in sources)
        {
            var discovery = new ZeDiscovery()
                .FromAssembly(Assembly.LoadFrom(source));

            foreach (var test in discovery)
            {
                discoverySink.SendTestCase(new TestCase(
                    $"{test.Class.FullName}::{test.Method.Name}",
                    new Uri(Constants.ExecutorUri),
                    source));
            }
        }

    }
}