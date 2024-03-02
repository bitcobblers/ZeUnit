namespace ZeUnit.Demo.CalculatorTests.DemoCalculator;

public class DictionarySetter<TKey, TValue> : Dictionary<TKey, TValue>
    where TKey : notnull
{
    public DictionarySetter<TKey, TValue> Upsert(TKey key, TValue value)
    {
        if (!ContainsKey(key))
        {
            Add(key, value);
        }
        else
        {
            this[key] = value;
        }

        return this;
    }
}
