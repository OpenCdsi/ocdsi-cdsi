using System.Runtime.CompilerServices;

namespace OpenCdsi.Cdsi
{
    public static class SystemLinqHelpers
    {
        public static IDictionary<TKey, TValue> AsMap<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            return new Dictionary<TKey, TValue>(collection);
        }

        public static T Second<T>(this IEnumerable<T> items)
        {
            return items.ToList()[1];
        }

        public static void AddAll<T>(this IList<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static IEnumerable<T> AsEnumerable<T>(this LinkedListNode<T> node, bool reverse = false)
        {
            var c = node;
            while (c != null)
            {
                yield return c.Value;
                c = reverse ? c.Previous : c.Next;
            }
        }
    }
}
