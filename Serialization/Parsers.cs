using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ocdsi.Serialization
{
    public static class Parsers
    {
        public static T ParseOrDefault<T>(this string str) where T : Enum
        {
            return str.ParseOrDefault<T>(RegexOptions.IgnoreCase);
        }

        public static T ParseOrDefault<T>(this string str, RegexOptions options) where T : Enum
        {
            var re = new Regex(str, options);
            var values = Enum.GetValues(typeof(T));
            foreach (var value in values)
            {
                if (re.IsMatch(value.ToString()))
                {
                    return (T)value;
                }
            }
            return (T)values.GetValue(0);
        }
    }
}
