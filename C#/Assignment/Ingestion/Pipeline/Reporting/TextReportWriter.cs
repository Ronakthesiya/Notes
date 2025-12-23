using Ingestion.Pipeline.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Reporting
{
    /// <summary>
    /// Writes a plain-text report.
    /// Marked sealed: writer behavior is simple and not expected to be extended.
    /// </summary>
    public sealed class TextReportWriter<T> : IReportWriter<T>
    {
        public void WriteReport(IEnumerable<T> items, string outputPath)
        {
            File.WriteAllLines(outputPath, items.Select(i => i!.ToString()));
        }
    }

}
