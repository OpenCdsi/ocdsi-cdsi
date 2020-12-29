using Cdsi.SupportingData;
using System.Reflection;
using System.Xml.Serialization;

namespace Cdsi.ReferenceData
{
    public static class ScheduleCollection
    {
        public static scheduleSupportingData Create()
        {
            var name = "Cdsi.SupportingData.xml.ScheduleSupportingData.xml";
            var assembly = Assembly.GetAssembly(typeof(scheduleSupportingData));
            var resource = assembly.GetManifestResourceStream(name);
            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            return (scheduleSupportingData)deserializer.Deserialize(resource);
        }
    }
}
