using System.Collections.Generic;

namespace System.Linq
{
    public static class SystemLinqHelpers
    {
        public static IDictionary<TKey, TValue> AsMap<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            return new Dictionary<TKey, TValue>(collection);
        }
    }
}
