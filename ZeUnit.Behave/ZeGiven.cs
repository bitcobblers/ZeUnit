using System.Linq.Expressions;

namespace ZeUnit.Behave
{
    public class ZeGivenProperty<TState,TType> : ZeGiven<TState>
    {
        private readonly Expression<Func<TState, TType>> property;
        private readonly Func<TType> value;

        public ZeGivenProperty(Expression<Func<TState, TType>> property, Func<TType> value)         
        {
            this.property = property;
            this.value = value;
        }

        public override void Do(TState state)
        {            
        }
    }

 

    public abstract class ZeGiven<TState> : IBehaviorAction<TState>
    {                
        protected ZeGiven()
        {
        }

        public ZeGiven(string message)
        {            
            Message = $"GIVEN:: {message}";
        }
        
        public string Message { get; protected set; }

        public abstract void Do(TState state);     
    }
}