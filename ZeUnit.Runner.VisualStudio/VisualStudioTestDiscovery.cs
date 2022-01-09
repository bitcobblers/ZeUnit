using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.Reflection;

namespace ZeUnit.Runner.VisualStudio
{
    [FileExtension(".dll")]
    [FileExtension(".exe")]
    [DefaultExecutorUri("ZeUnit.Runner.VisualStudio.VisualStudioZeUnitExecutor")]
    public class VisualStudioTestDiscovery : ITestDiscoverer
    {
        public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger, ITestCaseDiscoverySink discoverySink)
        {
            Console.WriteLine("test");
            foreach (var source in sources)
            {
                var discovery = new ZeDiscovery()
                    .FromAssembly(Assembly.LoadFrom(source));

                foreach (var test in discovery)
                {
                    discoverySink.SendTestCase(new TestCase(
                        $"{test.Class.FullName}::{test.Method.Name}",
                        new Uri("ZeUnit.Runner.VisualStudio.VisualStudioZeUnitExecutor"),
                        source));
                }
            }

        }
    }
}