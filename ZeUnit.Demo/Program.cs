// See https://aka.ms/new-console-template for more information

using System.Reactive.Linq;
using ZeUnit.Story;
var builder = new ZeBuilder()
    .With(discovery => discovery.FromAssembly(typeof(Program).Assembly))
    .With(new ConsoleReporter(),
            new StoryReporter());

await ZeGlobal.Unit(builder).LastAsync();
return 0;