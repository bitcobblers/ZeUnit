// See https://aka.ms/new-console-template for more information

using ZeUnit.Activators;

namespace ZeUnit;

public class ClassActivatorFactory : ActivatorFactory<IZeClassActivator, CoreClassActivator>
{
}
