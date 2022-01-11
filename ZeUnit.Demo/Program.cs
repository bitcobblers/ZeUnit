// See https://aka.ms/new-console-template for more information

return await Ze.Unit(
    discovery => discovery.FromAssembly(typeof(Program).Assembly),
//    new TeamCityReporter(),
//    new HtmlFileReporter(),
    new ConsoleReporter());