namespace ZeUnit.Behave
{
    public class ZeGiven : IBehaviorAction
    {
        private readonly Action action;

        public ZeGiven(string message, Action action)
        {
            this.action = action; 
            Message = $"GIVEN:: {message}";
        }

        public string Message { get; }

        public virtual void Do() 
        {
            (action ?? (()=> {}))();
        }
    }
}