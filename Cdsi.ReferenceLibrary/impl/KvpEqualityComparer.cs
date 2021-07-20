using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Cdsi.ReferenceLibrary
{
    class KvpEqualityComparer : IEqualityComparer<KeyValuePair<string, string>>
    {
        public bool Equals([AllowNull] KeyValuePair<string, string> x, [AllowNull] KeyValuePair<string, string> y)
        {
            return x.Key == y.Key && x.Value == y.Value;
        }

        public int GetHashCode([DisallowNull] KeyValuePair<string, string> obj)
        {
            return $"{obj.Key}{obj.Value}".GetHashCode();
        }
    }
}
