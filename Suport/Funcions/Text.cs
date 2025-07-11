using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Examen.Suport.Funcions
{
    public static class Text
    {
        public static string Serialitzar<T>(this T obj, Formatting formatting = Formatting.None, bool? cleanType = false)
        {
            if (!cleanType.HasValue &&
                formatting == Formatting.Indented)
                cleanType = true;

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = formatting,
                Converters = new List<JsonConverter>()
            };

            var converter = new StringEnumConverter();
            settings.Converters.Add(converter);

            var json = JsonConvert.SerializeObject(obj, settings);
            if (cleanType.HasValue && !cleanType.Value || formatting == Formatting.None)
                return json;

            var lines = json.Replace(Environment.NewLine, "^").Split('^');
            lines = lines.Where(l => !l.Contains("$type")).ToArray();
            json = string.Join(Environment.NewLine, lines);
            return json;
        }

        public static T Deserialitzar<T>(this string json)
        {
            if (string.IsNullOrEmpty(json))
                return default;

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Converters = new List<JsonConverter>()
            };
            var converter = new StringEnumConverter();
            settings.Converters.Add(converter);

            var ret = JsonConvert.DeserializeObject<T>(json, settings);

            return ret;
        }
    }
}
