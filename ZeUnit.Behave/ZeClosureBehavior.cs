namespace ZeUnit.Behave
{
    public abstract class ZeSimpleBehavior
    {
        protected ZeResult Given(string message, Action action = null)
        {
            return new BehaviorResult($"Given: '{message}'", () =>
            {
                (action ?? (() => { }))();
            });
        }

        protected ZeResult When(string message, Action action)
        {
            return new BehaviorResult($"When: '{message}'", () =>
            {
                (action ?? (() => { }))();
            });
        }

        protected ZeResult Then(string message, Func<ZeResult> action)
        {
            return new BehaviorResult($"Then: '{message}'", () =>
            {
                (action ?? (() => { return Ze.Is; }))();
            });
        }      
    }
}