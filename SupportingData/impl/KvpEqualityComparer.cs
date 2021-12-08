using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cdsi.SupportingDataLibrary
{
    class KvpEqualityComparer : IEqualityComparer<KeyValuePair<string, string>>
    {
        public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            return x.Key.Equals(y.Key) && x.Value.Equals(y.Value);
        }

        public int GetHashCode([DisallowNull] KeyValuePair<string, string> obj)
        {
            return $"{obj.Key}{obj.Value}".GetHashCode();
        }
    }

    class KeyEqualityComparer : IEqualityComparer<KeyValuePair<string, string>>
    {
        public bool Equals(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
        {
            return x.Key.Equals(y.Key);
        }

        public int GetHashCode([DisallowNull] KeyValuePair<string, string> obj)
        {
            return $"{obj.Key}".GetHashCode();
        }
    }
}
