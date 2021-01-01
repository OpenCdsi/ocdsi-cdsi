using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Cdsi.SupportingData;

namespace Cdsi.ReferenceLibrary
{
    public static class Factories
    {
        private static readonly Regex re = new Regex("Cdsi.SupportingData.xml.AntigenSupportingData-\\s*([\\w\\s]*)-508.xml");
        public static IDictionary<string, antigenSupportingData> CreateAntigenMap()
        {
            var deserializer = new XmlSerializer(typeof(antigenSupportingData));
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            return assembly.GetManifestResourceNames()
                  .Select(x => Tuple.Create(x, re.Match(x)))
                  .Where(x => x.Item2.Success)
                  .Select(x => assembly.GetManifestResourceStream(x.Item1))
                  .Select(x => (antigenSupportingData)deserializer.Deserialize(x))
                  .Select(x => KeyValuePair.Create(x.series[0].targetDisease, x))
                  .AsMap();
        }

        public static IDictionary<string, string> CreateVaccineTypeMap()
        {
            return Reference.Antigen.Values
                    .SelectMany(x => x.series)
                    .SelectMany(x => x.seriesDose)
                    .SelectMany(x => x.preferableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))
                        .Concat(x.allowableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))))
                    .Where(x => !string.IsNullOrWhiteSpace(x.Key))
                    .Distinct(new KvpEqualityComparer())
                    .AsMap();
        }

        public static scheduleSupportingData CreateSupportingData()
        {
            var name = "Cdsi.SupportingData.xml.ScheduleSupportingData.xml";
            var assembly = Assembly.GetAssembly(typeof(Metadata));
            var resource = assembly.GetManifestResourceStream(name);
            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            return (scheduleSupportingData)deserializer.Deserialize(resource);
        }
    }
}
