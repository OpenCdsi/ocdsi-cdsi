using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cdsi.SupportingData
{
    public class Repository
    {
        public string ResourcePath { get; init; }

        public Repository(string resourcePath)
        {
            ResourcePath = resourcePath;
        }

        public antigenSupportingData Antigen(string name)
        {
            string fname = $"AntigenSupportingData- {name}-508.xml";
            return ReadFile<antigenSupportingData>(fname);
        }

        public scheduleSupportingData Schedule()
        {
            string fname = @"ScheduleSupportingData.xml";
            return ReadFile<scheduleSupportingData>(fname);
        }

        internal T ReadFile<T>(string fname)
        {
            var path = Path.Combine(ResourcePath, fname);
            var finfo = new FileInfo(path);

            var deserializer = new XmlSerializer(typeof(T));
            var data = (T)deserializer.Deserialize(finfo.OpenRead());
            if (data != null)
            {
                return data;
            }
            else
            {
                throw new ApplicationException($"Can't deserialize file {fname}");
            }
        }
    }
}
