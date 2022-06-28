namespace ZeUnit.Behave
{
    public class ZeBehvaviorContext : Dictionary<string, object>
    {
        public void Set<TType>(string name, TType obj)
        {
            if (!this.ContainsKey(name))
            {
                Add(name, obj);
            }
            else
            {
                this[name] = obj;
            }
        }

        public TType? Get<TType>(string name)
        {            
            return this.ContainsKey(name)
                ? (TType)this[name]
                : default;
        }
    }
}