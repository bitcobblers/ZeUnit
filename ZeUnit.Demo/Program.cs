// See https://aka.ms/new-console-template for more information

using ZeUnit.Story;

await Ze.Unit(
    discovery => discovery.FromAssembly(typeof(Program).Assembly),
//    new TeamCityReporter(),
//    new HtmlFileReporter(),
    new ConsoleReporter(),
    new StoryReporter());

return 0;