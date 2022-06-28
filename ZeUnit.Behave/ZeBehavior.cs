namespace ZeUnit.Behave
{
    public class BehaviorResult : ZeResult
    {
        public BehaviorResult(string message, Action action) 
        {
            var attempted = new AssertPassed(message);
            this.Assert(attempted);
            
            try
            {
                action();
            }
            catch (Exception ex)
            {
                attempted.Status = ZeStatus.Failed;
                this.Assert(new AssertError(ex));
            }            
        }
    }

    public abstract class ZeBehavior
    {
        protected ZeResult Given(string message, Action action = null)
        {
            return new BehaviorResult($"Given: '{message}'", () =>
            {
                (action ?? (() => { }))();
            });
        }

        protected ZeResult When(string message, Action action)
        {
            return new BehaviorResult($"When: '{message}'", () =>
            {
                (action ?? (() => { }))();
            });
        }

        protected ZeResult Then(string message, Func<ZeResult, ZeResult> action)
        {
            return new BehaviorResult($"Then: '{message}'", () =>
            {
                (action ?? ((result) => { return result; }))(new ZeResult());
            });
        }      
    }
}