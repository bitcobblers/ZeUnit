namespace ZeUnit.Behave
{
    public abstract class ZeBehavior
    {
        protected ZeResult Given(ZeGiven given)
        {
            return new BehaviorResult(given.Message, given.Do);
        }
        protected ZeResult Given(string message, Action action = null)
        {
            return this.Given(new ZeGiven(message, action));
        }

        protected ZeResult When(ZeWhen given)
        {
            return new BehaviorResult(given.Message, given.Do);
        }
        protected ZeResult When(string message, Action action)
        {
            return this.When(new ZeWhen(message, action));
        }

        protected ZeResult Then(ZeThen then)
        {
            return new BehaviorResult(then.Message, () => then.Do());
        }
        protected ZeResult Then(string message, Func<ZeResult> action)
        {
            return this.Then(new ZeThen(message,action));
        }      
    }
}