using System.Collections.Generic;

namespace cdsi.evaluation
{
    public interface IEnv: IDictionary<object, object>
    {
        object Get(object key);
        T Get<T>(object key);
        void Set(object key, object value);
    }
}