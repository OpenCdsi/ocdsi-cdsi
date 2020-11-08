using System;
using System.Collections.Generic;
using System.Text;

namespace cdsi.evaluation
{
    public class Env : Dictionary<object, object>, IEnv
    {
        public object Get(object key)
        {
            return this[key];
        }

        public T Get<T>(object key)
        {
            return (T)this[key];
        }

        public void Set(object key, object value)
        {
            this[key] = value;
        }
    }
}
