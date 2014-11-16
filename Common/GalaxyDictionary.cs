



namespace GalaxyGuide.Common
{

    using System.Collections.Generic;

    public class GalaxyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public void AddUpdateKey(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                this[key] = value;
            }
            else
            {
                Add(key, value);
            }
        }
    }
}
