using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Cdsi.Serialization
{
    public class JsonRegExConverter<T> :JsonConverterFactory where T : struct
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(T);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new RegExConverter<T>();
        }
    }

    public class RegExConverter<T> : JsonConverter<T> where T : struct
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var re =new Regex(reader.GetString()!,RegexOptions.IgnoreCase);
            foreach(var value in Enum.GetValues(typeof(T)))
            {
                if (re.IsMatch(value.ToString()))
                {
                    return (T)value;
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
