namespace ZeUnit.Behave
{
    public abstract class ZeGiven<TState> : IBehaviorAction<TState>
    {                
        public ZeGiven(string message)
        {            
            Message = $"GIVEN:: {message}";
        }
        
        public string Message { get; }

        public abstract void Do(TState state);     
    }
}