using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.Serialization
{
    public static class SummarySerializer
    {
        public static string ToJson(WriteObj obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static string ToXml(WriteObj obj)
        {
            var serializer = new XmlSerializer(typeof(WriteObj));
            using var sw = new StringWriter();
            serializer.Serialize(sw, obj);
            return sw.ToString();
        }
    }

}
