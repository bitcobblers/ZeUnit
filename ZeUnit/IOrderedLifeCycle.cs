namespace ZeUnit;

public abstract class OrderedSuite 
    : IZeLifecycle<SingletonLifecycleFactory>,
      IZeDependencyOrder
{
}