// See https://aka.ms/new-console-template for more information

using ZeUnit;

var zeDiscovery = new ZeDiscovery()
    .FromAssembly(typeof(Program).Assembly);

var zeRunner = new ZeRunner();

var reporter = new ZeReporter();

foreach (var test in zeDiscovery)
{
    var result = zeRunner.Run(test);        
    reporter.Report(test, result);
}
