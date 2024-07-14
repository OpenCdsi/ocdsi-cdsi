using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cdsi
{
    public static class StringHelpers
    {
        public static string Pack(this string s)
        {
            return Regex.Replace(s, @"[\s\W]", string.Empty);
        }
    }
}
