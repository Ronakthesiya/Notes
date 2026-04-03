using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Abstractions
{
    /// <summary>
    /// Abstraction for writing reports in various output formats.
    /// </summary>
    public interface IReportWriter<T>
    {
        void WriteReport(IEnumerable<T> items, string outputPath);
    }

}
