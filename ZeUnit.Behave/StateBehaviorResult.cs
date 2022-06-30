using Lamar;

namespace ZeUnit.Behave
{
    public class StateBehaviorResult<TState> : ZeResult
    {
        public StateBehaviorResult(IBehaviorAction<TState> action, TState state)
        {
            var attempted = new AssertPassed(action.Message);
            this.Assert(attempted);

            try
            {
                action.Do(state);
            }
            catch (Exception ex)
            {
                attempted.Status = ZeStatus.Failed;
                this.Assert(new AssertError(ex));
            }
        }
    }
}