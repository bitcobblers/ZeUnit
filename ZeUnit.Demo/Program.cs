// See https://aka.ms/new-console-template for more information

Ze.Unit<LamarTestActivator>(
    discovery => discovery.FromAssembly(typeof(Program).Assembly),
    new ConsoleReporter());