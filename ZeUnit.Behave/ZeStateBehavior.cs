namespace ZeUnit.Behave
{
    public abstract class ZeStateBehavior<TState>
        where TState : class, new()
    {
        private readonly TState seed = new TState();
        

        protected ZeResult Given(ZeGiven<TState> given)            
        {
            return new StateBehaviorResult<TState>(given, this.seed);
        }


        protected ZeResult When(ZeWhen<TState> when)
        {
            return new StateBehaviorResult<TState>(when, this.seed);
        }


        protected ZeResult Then(ZeThen<TState> then)            
        {
            return then.Do(seed);
        }        
    }    
}