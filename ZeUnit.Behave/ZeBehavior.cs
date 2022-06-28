using Lamar;

namespace ZeUnit.Behave
{
    public abstract class ZeContainerBehavior
    {
        private Container container = new Container(r => { });

        protected ZeResult Given<TGiven>(string message = "") 
            where TGiven : ZeGiven
        {
            return Ze.Is;
        }

        protected ZeResult When<TWhen>(string message = "")
         where TWhen : ZeWhen
        {
            return Ze.Is;
        }

        protected ZeResult Then<TThen>(string message = "")
            where TThen : ZeThen
        {
            return Ze.Is;
        }
    }    

    public interface IBehaviorAction
    {
        string Message { get; }
        IEnumerable<ServiceRegistry> Do();
    }

    public interface IBehaviorTest
    {
        string Message { get; }

        ZeResult Do();
    }

    public class ZeGiven : IBehaviorAction
    {
        private readonly Action action;

        public ZeGiven(string message, Action action)
        {
            this.action = action;
            Message = $"GIVEN:: {message}";
        }

        public string Message { get; }

        public virtual IEnumerable<ServiceRegistry> Do()
        {
            // (action ?? (() => { }))();
            yield break;
        }

    }
    public class ZeThen : IBehaviorTest
    {
        private readonly Func<ZeResult> fn;

        public ZeThen(string message, Func<ZeResult> fn)
        {
            Message = $"THEN:: '{message}'";
            this.fn = fn;
        }

        public string Message { get; }

        public virtual ZeResult Do()
        {
            return (fn ?? (() => { return Ze.Is; }))();
        }
    }

    public class ZeWhen : IBehaviorAction
    {
        private readonly Action action;

        public ZeWhen(string message, Action action)
        {
            this.action = action;
            this.Message = $"WHEN:: '{message}'";
        }

        public string Message { get; }

        public virtual IEnumerable<ServiceRegistry> Do()
        {
            yield break;
        }
    }
}