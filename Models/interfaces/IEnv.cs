using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface IEnv : IDictionary<string, object>
    {
        T Get<T>(string key);
        void Set(string key, object value);
    }
}
