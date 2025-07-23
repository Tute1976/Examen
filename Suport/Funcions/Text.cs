using Examen.Suport.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global

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
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = formatting,
                Converters = new List<JsonConverter>()
            };

            var converter = new StringEnumConverter();
            settings.Converters.Add(converter);
            settings.Converters.Add(new IpAddressConverter());

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
            settings.Converters.Add(new IpAddressConverter());

            var ret = JsonConvert.DeserializeObject<T>(json, settings);

            return ret;
        }

        public static void Desar(this List<Aplicacio> aplicacions, string fitxer)
        {
            var json = aplicacions.Serialitzar(Formatting.Indented, true);
            File.WriteAllText(fitxer, json, Encoding.UTF8);
        }

        public static List<Aplicacio> Llegir(this List<Aplicacio> aplicacions, string fitxer)
        {
            var json = File.ReadAllText(fitxer, Encoding.UTF8);
            return json.Deserialitzar<List<Aplicacio>>();
        }

        public static string SiNo(this bool b)
        {
            return b ? "Sí" : "No";
        }

        public static string ToBase64(this string text)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                var base64 = Convert.ToBase64String(bytes);
                return base64;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return text;
        }

        public static string FromBase64(this string base64)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64);
                var text = Encoding.UTF8.GetString(bytes);
                return text;
            }
            catch (Exception ex)
            {
                ex.Mostrar();
            }

            return base64;
        }

        public static string CompressToBase64(this string data)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(data).Compress());
        }

        public static string DecompressFromBase64(this string data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data).Decompress());
        }

        public static byte[] Compress(this byte[] data)
        {
            using var sourceStream = new MemoryStream(data);
            using var destinationStream = new MemoryStream();
            sourceStream.CompressTo(destinationStream);
            return destinationStream.ToArray();
        }

        public static byte[] Decompress(this byte[] data)
        {
            using var sourceStream = new MemoryStream(data);
            using var destinationStream = new MemoryStream();
            sourceStream.DecompressTo(destinationStream);
            return destinationStream.ToArray();
        }

        public static void CompressTo(this Stream stream, Stream outputStream)
        {
            using var gZipStream = new GZipStream(outputStream, CompressionMode.Compress);
            stream.CopyTo(gZipStream);
            gZipStream.Flush();
        }

        public static void DecompressTo(this Stream stream, Stream outputStream)
        {
            using var gZipStream = new GZipStream(stream, CompressionMode.Decompress);
            gZipStream.CopyTo(outputStream);
        }

        public static string ToNaturalString(this TimeSpan temps)
        {
            var naturalString = $" {temps.Days}d {temps.Hours}h {temps.Minutes}m {temps.Seconds}s";
            naturalString = naturalString.Replace(" 0d", "");
            naturalString = naturalString.Replace(" 0h", "");
            naturalString = naturalString.Replace(" 0m", "");
            naturalString = naturalString.Replace(" 0s", "");
            naturalString = naturalString.Trim();

            if (string.IsNullOrEmpty(naturalString))
                naturalString = "0s";

            return naturalString;
        }
    }
}
