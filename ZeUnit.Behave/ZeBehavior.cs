namespace ZeUnit.Behave
{
    public abstract class ZeBehavior
    {
        protected ZeResult Given(string message, Action action = null)
        {
            return new ZeResult(this.Try($"Given: '{message}'", () =>
            {
                (action ?? (() => { }))();
            }));
        }

        protected ZeResult When(string message, Action action)
        {
            return new ZeResult(this.Try($"When: '{message}'", () =>
            {
                (action ?? (() => { }))();
            }));
        }

        protected ZeResult Then(string message, Func<ZeResult, ZeResult> action)
        {
            return new ZeResult(this.Try($"Then: '{message}'", () =>
            {
                (action ?? ((result) => { return result; }))(new ZeResult());
            }));
        }

        private IEnumerable<ZeAssert> Try(string message, Action action)
        {
            var attempted = new AssertPassed(message);
            var result = new ZeAssert[] { attempted };
            try
            {
                action();
            }
            catch (Exception ex)
            {
                attempted.Status = ZeStatus.Failed;
                result = result.Concat(new[] { new AssertError(ex) }).ToArray();
            }

            return result;
        }

    }
}