namespace ZeUnit.Demo.DemoCalculator
{
    public class LatestDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public LatestDictionary<TKey, TValue> AddOrUpdate(TKey key, TValue value)
        {
            if (!this.ContainsKey(key))
            {
                this.Add(key, value);
            }
            else
            {
                this[key] = value;
            }

            return this;
        }
    }
}
