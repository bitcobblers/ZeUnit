namespace ZeUnit.Behave
{
    public class ZeWhen : IBehaviorAction
    {
        private readonly Action action;

        public ZeWhen(string message, Action action)
        {
            this.action = action;
            this.Message = $"WHEN:: '{message}'";
        }

        public string Message { get; }

        public virtual void Do() 
        {
            
        }
    }
}