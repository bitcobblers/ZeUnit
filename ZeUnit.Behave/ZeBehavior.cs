namespace ZeUnit.Behave
{
    public abstract class ZeBehavior
    {        
        protected ZeResult Given(string message, Action action = null)
        {
            var given = new AssertPassed($"Given: '{message}'");
            return new ZeResult(this.Try(given, () =>
            {
                (action ?? (() => { }))();
            }));
        }

        protected ZeResult When(string message, Action action)
        {
            var when = new AssertPassed($"When: '{message}'");
            return new ZeResult(this.Try(when, () =>
            {
                (action ?? (() => { }))();
            }));
        }

        protected ZeResult Then(string message, Func<ZeResult, ZeResult> action)
        {
            var when = new AssertPassed($"Then: '{message}'");
            return new ZeResult(this.Try(when, () =>
            {
                (action ?? ((result) => { return result; }))(new ZeResult());
            }));
        }

        private IEnumerable<ZeAssert> Try(ZeAssert attempted, Action action)
        {
            var result = new[] { attempted };
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