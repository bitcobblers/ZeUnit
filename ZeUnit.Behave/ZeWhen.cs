namespace ZeUnit.Behave
{
    public abstract class ZeWhen<TState> : IBehaviorAction<TState>
    {
        public ZeWhen(string message)
        {
            this.Message = $"WHEN:: '{message}'";
        }

        public string Message { get; }

        public abstract void Do(TState state);
    }
}