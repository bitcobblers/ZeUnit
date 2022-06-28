namespace ZeUnit.Behave
{
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
            return (fn?? (() => { return Ze.Is; }))();
        }
    }
}