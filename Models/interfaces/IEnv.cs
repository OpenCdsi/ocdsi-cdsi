﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi
{
    public interface IEnv : IDictionary<object, object>
    {
        T Get<T>(object key);
        void Set(object key, object value);
    }
}
