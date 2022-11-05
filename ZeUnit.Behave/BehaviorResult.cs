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
}