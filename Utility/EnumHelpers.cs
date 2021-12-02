using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Enum
    {
        public static T TryParse<T>(string s)
        {
            try
            {
                return (T)System.Enum.Parse(typeof(T), s);
            }
            catch
            {
                return default(T);
            }
        }
    }
}
