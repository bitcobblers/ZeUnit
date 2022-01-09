using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;

namespace ZeUnit.Runner.VisualStudio
{
    [ExtensionUri("ZeUnit.Runner.VisualStudio.VisualStudioZeUnitExecutor")]
    public class VisualStudioZeUnitExecutor : ITestExecutor
    { 
        public void RunTests(IEnumerable<TestCase> tests, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            Console.WriteLine("test");

        }

        public void RunTests(IEnumerable<string> sources, IRunContext runContext, IFrameworkHandle frameworkHandle)
        {
            Console.WriteLine("test");
        }

        public void Cancel()
        {
            Console.WriteLine("test");
        }
    }
}