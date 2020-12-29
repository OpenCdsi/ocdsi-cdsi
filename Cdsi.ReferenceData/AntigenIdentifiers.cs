using System.Linq;
using System.Text.RegularExpressions;

namespace Cdsi.ReferenceData
{
    public class AntigenIdentifier : IAntigenIdentifier
    {
        public string Name { get; internal set; }
        public static IAntigenIdentifier Parse(string src)
        {
            var components = AntigenIdentifierParser.Parse(src);
            return new AntigenIdentifier()
            {
                Name = components[0]
            };
        }
    }

    public class AntigenSeriesIdentifier : AntigenIdentifier, IAntigenSeriesIdentifier
    {
        public string SeriesName { get; internal set; }
        public static new IAntigenSeriesIdentifier Parse(string src)
        {
            var components = AntigenIdentifierParser.Parse(src);
            return new AntigenSeriesIdentifier()
            {
                Name = components[0],
                SeriesName = components[1]
            };
        }
    }

    public class AntigenSeriesDoseIdentifier : AntigenSeriesIdentifier, IAntigenSeriesDoseIdentifier
    {
        public string DoseName { get; internal set; }
        public static new IAntigenSeriesDoseIdentifier Parse(string src)
        {
            var components = AntigenIdentifierParser.Parse(src);
            return new AntigenSeriesDoseIdentifier()
            {
                Name = components[0],
                SeriesName = components[1],
                DoseName = components[2]
            };
        }
    }

    internal static class AntigenIdentifierParser
    {
        private static readonly Regex re = new Regex("[:;,\t]");

        public static string[] Parse(string src)
        {
            return re.Split(src).Select(el => el.Trim()).ToArray();
        }
    }
}
