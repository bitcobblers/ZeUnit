namespace ZeUnit.Demo.DemoCalculator.Operations
{
    public class DictionarySetter<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public DictionarySetter<TKey, TValue> AddOrUpdate(TKey key, TValue value)
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
