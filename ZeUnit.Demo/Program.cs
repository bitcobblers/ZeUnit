// See https://aka.ms/new-console-template for more information
Ze.Unit(
    discovery => discovery.FromAssembly(typeof(Program).Assembly),
    new ConsoleReporter(),
    new TeamCityReporter(),
    new HtmlFileReporter());