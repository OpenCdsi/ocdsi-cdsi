using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Cdsi.ReferenceLibrary
{
    class KvpEqualityComparer : IEqualityComparer<KeyValuePair<string, string>>
    {
        public bool Equals([AllowNull] KeyValuePair<string, string> x, [AllowNull] KeyValuePair<string, string> y)
        {
            return x.Key == y.Key;
        }

        public int GetHashCode([DisallowNull] KeyValuePair<string, string> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
}
