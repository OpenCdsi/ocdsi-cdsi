using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Cdsi.SupportingDataLibrary
{
    public static class Factories
    {
        private const string ScheduleResourceName = "SupportingDataLibrary.xml.ScheduleSupportingData.xml";
       private static readonly Regex AntigenResourceNameRegex = new Regex("SupportingDataLibrary.xml.AntigenSupportingData-\\s*([\\w\\s]*)-508.xml");

        public static IDictionary<string, antigenSupportingData> CreateAntigenMap()
        {
            var deserializer = new XmlSerializer(typeof(antigenSupportingData));
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            return assembly.GetManifestResourceNames()
                  .Select(x => Tuple.Create(x, AntigenResourceNameRegex.Match(x)))
                  .Where(x => x.Item2.Success)
                  .Select(x => assembly.GetManifestResourceStream(x.Item1))
                  .Select(x => (antigenSupportingData)deserializer.Deserialize(x))
                  .Select(x => KeyValuePair.Create(x.series[0].targetDisease, x))
                  .AsMap();
        }

        public static IDictionary<string, string> CreateVaccineTypeMap()
        {
            return SupportingData.Antigen.Values
                      .SelectMany(x => x.series)
                      .SelectMany(x => x.seriesDose)
                      .SelectMany(x => x.preferableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))
                         .Concat(x.allowableVaccine.Select(xx => KeyValuePair.Create(xx.cvx, xx.vaccineType))))
                     .Where(x => !string.IsNullOrWhiteSpace(x.Key))
                     .Distinct(new 
                     KeyEqualityComparer())
                     .OrderBy(x => x.Key)
                     .AsMap();
        }

        public static scheduleSupportingData CreateSupportingData()
        {
            var assembly = Assembly.GetAssembly(typeof(Metadata));
            var resource = assembly.GetManifestResourceStream(ScheduleResourceName);
            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            return (scheduleSupportingData)deserializer.Deserialize(resource);
        }
    }
}
