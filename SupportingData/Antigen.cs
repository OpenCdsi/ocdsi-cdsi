using Ocdsi.SupportingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCdsi.Cdsi
{
    public static class Antigen
    {
        private static Repository repository;
        public static void Initialize(Repository repository)
        {
            Antigen.repository = repository;
        }
        public static void Initialize(string resourcePath)
        {
            Initialize(new Repository(resourcePath));
        }
        public static antigenSupportingData Get(string name)
        {
            return repository.Antigen(name);
        }
    }
}
