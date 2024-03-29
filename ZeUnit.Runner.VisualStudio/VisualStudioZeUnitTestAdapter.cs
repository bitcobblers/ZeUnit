﻿namespace ZeUnit.TestAdapter;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

[FileExtension(".dll")]
[FileExtension(".exe")]
[Category("managed")]
[DefaultExecutorUri(Constants.ExecutorUri)]
[ExtensionUri(Constants.ExecutorUri)]
//[ExtensionUri(Constants.ExecutorUri)]
public class VisualStudioZeUnitTestAdapter : ITestDiscoverer, ITestExecutor
{
    private readonly ZeTestRunnerDiscovery testRunnerDiscovery;

    public VisualStudioZeUnitTestAdapter()
    {
        testRunnerDiscovery = new DefaultTestRunnerDiscovery();
    }

    public void DiscoverTests(IEnumerable<string> sources, IDiscoveryContext discoveryContext, IMessageLogger logger,
        ITestCaseDiscoverySink discoverySink)
    {
        logger.SendMessage(TestMessageLevel.Informational, "Attempting Discovery");
        foreach (var source in sources)
        {
            var testBuilder = new TestCaseBuilder(source);
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source);

            foreach (var test in discovery)
            {
                var msTest = testBuilder.Build(test);
                discoverySink.SendTestCase(msTest);
            }
        }
    }

    public void RunTests(IEnumerable<TestCase>? tests, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        frameworkHandle!.SendMessage(TestMessageLevel.Informational, "Running Tests");
        var sources = tests!.GroupBy(n => n.Source);
        var executionList = new List<Task>();
        var runner = new ZeRunner(testRunnerDiscovery.Runners());

        foreach (var source in sources)
        {
            var discovery = new ZeDiscovery(testRunnerDiscovery.SupportedTypes())
                .FromAssembly(source.Key);

            var classes = source.Select(n => (discovery.FirstOrDefault(z => z.Name == n.FullyQualifiedName), n))
                .GroupBy(pair => (pair.Item1?.Class, pair.Item1?.ClassFactory));

            foreach (var classPair in classes)
            {
                var (_, factory) = classPair.Key;
                foreach (var (zeTest, testCase) in classPair)
                {
                    var result = new TestResult(testCase);
                    if (zeTest == null)
                    {
                        result.Duration = TimeSpan.Zero;
                        result.Outcome = TestOutcome.Skipped;
                        frameworkHandle.RecordResult(result);
                        frameworkHandle.RecordEnd(testCase, result.Outcome);
                        continue;
                    }

                    executionList.Add(runner.Run(zeTest, factory!).Select(pair =>
                    {
                        var (_, Ze) = pair;                        
                        result.Duration = Ze.Duration;
                        result.Outcome = Ze.Any() && Ze.All(x => x.Status == ZeStatus.Passed)
                            ? TestOutcome.Passed
                            : TestOutcome.Failed;

                        foreach (var zeResult in Ze)
                        {
                            result.Messages.Add(new TestResultMessage(TestResultMessage.StandardOutCategory, zeResult.Message));
                        }
                        frameworkHandle.RecordResult(result);
                        frameworkHandle.RecordEnd(testCase, result.Outcome);
                        return Ze;
                    }).ToTask());
                }
            }
        }

        Task.WhenAll(executionList).Wait();
    }

    public void RunTests(IEnumerable<string>? sources, IRunContext? runContext, IFrameworkHandle? frameworkHandle)
    {
        frameworkHandle!.SendMessage(TestMessageLevel.Informational, "Starting Tests");

        var testCases =
            (from source in sources
             let builder = new TestCaseBuilder(source)
             let discoverer = new ZeDiscovery(testRunnerDiscovery.SupportedTypes()).FromAssembly(source)
             from test in discoverer
             select builder.Build(test))
            .ToArray();

        RunTests(testCases, runContext!, frameworkHandle!);
    }

    public void Cancel()
    {

    }
}