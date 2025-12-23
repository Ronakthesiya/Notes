using Ingestion.Pipeline.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ingestion.Pipeline.Reporting
{
    /// <summary>
    /// Writes an XML report.
    /// Marked sealed to preserve a stable XML schema.
    /// </summary>
    public sealed class XmlReportWriter<T> : IReportWriter<T>
    {
        public void WriteReport(IEnumerable<T> items, string outputPath)
        {
            var serializer = new XmlSerializer(typeof(List<T>));
            using var fs = File.Create(outputPath);
            serializer.Serialize(fs, items.ToList());
        }
    }

}
