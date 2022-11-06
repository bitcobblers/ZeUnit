namespace ZeUnit.Behave
{
    public abstract class ZeThen<TState> : IBehaviorTest<TState>
    {        
        public ZeThen(string message)
        {
            Message = $"THEN:: '{message}'";            
        }

        public string Message { get; }

        [ZeIgnore]
        public abstract ZeResult Do(TState state);
    }    
}