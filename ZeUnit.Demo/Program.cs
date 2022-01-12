// See https://aka.ms/new-console-template for more information

using ZeUnit.Story;

var failed = await Ze.Unit(
    discovery => discovery.FromAssembly(typeof(Program).Assembly),
//    new TeamCityReporter(),
//    new HtmlFileReporter(),
    new ConsoleReporter(),
    new StoryReporter());

if (failed > 0)
{
    Console.WriteLine($"Error: {failed} test(s) have failed execution");
}

return 0;