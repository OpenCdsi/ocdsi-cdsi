using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OpenCdsi.Cdsi
{
    public static class ObjectHelpers
    {
        public static bool AllNullProperties(this object obj)
        {
            var props = obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            return props.All(x => x.GetValue(obj, null) == null);
        }
    }
}
