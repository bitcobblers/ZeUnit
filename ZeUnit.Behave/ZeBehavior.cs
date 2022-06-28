using Lamar;

namespace ZeUnit.Behave
{
    public class ContainerBehaviorActionResult<TType> : ZeResult
        where TType : IBehaviorAction
    {
        public ContainerBehaviorActionResult(Container container, string errorMessage) 
        {            
            var instance = container.TryGetInstance<TType>();
            if (instance != null)
            {
                foreach (var assert in new BehaviorActionResult(instance, container))
                {
                this.Assert(assert);
                }
                    
            }

            this.Assert(new AssertError(
                new Exception(errorMessage)));
            
        }
    }

    public class BehaviorActionResult : BehaviorResult
    {
        public BehaviorActionResult(IBehaviorAction action, Container container) : base(action.Message, () => {
            var registry = action.Do();
            container.Configure(registry);
        })
        {
        }
    }

    public abstract class ZeContainerBehavior : IDisposable
    {
        private Container container = new Container(r => { });
        protected ZeResult Given<TGiven>() 
            where TGiven : ZeGiven, IBehaviorAction
        {
            var instance = container.TryGetInstance<TGiven>();
            if (instance != null)
            {
                return new BehaviorActionResult(instance, container);
            }

            return Ze.Is.Assert(new AssertError(
                new Exception($"Could not load Given type {nameof(TGiven)} from container.")));
        }

        protected ZeResult Given(ZeGiven given)            
        {
            return new BehaviorActionResult(given, container);
        }

        protected ZeResult When<TWhen>()
         where TWhen : ZeWhen, IBehaviorAction
        {
            var instance = container.TryGetInstance<TWhen>();
            if (instance != null)
            {
                return this.When(instance);
            }

            return Ze.Is.Assert(new AssertError(
                new Exception($"Could not load When type {nameof(TWhen)} from container.")));
        }

        protected ZeResult When(ZeWhen when)
        {
            return new BehaviorActionResult(when, container);
        }


        protected ZeResult Then<TThen>()
            where TThen : ZeThen
        {
            var instance = container.TryGetInstance<TThen>();
            if (instance != null)
            {
                return this.Then(instance);
            }

            return Ze.Is.Assert(new AssertError(
                new Exception($"Could not load Then type {nameof(TThen)} from container.")));
        }

        protected ZeResult Then(ZeThen then)            
        {
            return Ze.Is;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
    }    

    public interface IBehaviorAction
    {
        string Message { get; }
        ServiceRegistry Do();
    }

    public interface IBehaviorTest
    {
        string Message { get; }

        ZeResult Do();
    }

    public abstract class ZeBehaviorAction : IBehaviorAction {
                        
        public string Message { get; protected set; }

        protected abstract void Do(ServiceRegistry registry);

        public ServiceRegistry Do()
        {
            var registry = new ServiceRegistry();
            this.Do(registry);
            return registry;
        }
    }

    public abstract class ZeGiven : ZeBehaviorAction, IBehaviorAction
    {                
        public ZeGiven(string message)
        {            
            Message = $"GIVEN:: {message}";
        }       
    }

    public abstract class ZeWhen : ZeBehaviorAction, IBehaviorAction
    {
        public ZeWhen(string message)
        {
            this.Message = $"WHEN:: '{message}'";
        }
    }

    public abstract class ZeThen : IBehaviorTest
    {        
        public ZeThen(string message)
        {
            Message = $"THEN:: '{message}'";            
        }

        public string Message { get; }

        public abstract ZeResult Do();
    }    
}