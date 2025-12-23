using Ingestion.Pipeline.Abstractions;
using Ingestion.Pipeline.Extensions;
using Ingestion.Pipeline.Importers;
using Ingestion.Pipeline.Models;
using Ingestion.Pipeline.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Cli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var opts = new Options();

            var books = ImportRunner.ImportAll(opts.InputDir).ToList();

            var summary = new WriteObj
            {
                Total = books.Count,
                TopPenalties = books.TopBy(b => b.Penalty, 5).ToList(),
                Conditions = books.ToConditionCounts().ToList()
            };

            var json = SummarySerializer.ToJson(summary);
            File.WriteAllText(opts.Output, json);

            //var xml = SummarySerializer.ToXml(summary);
            //File.WriteAllText(Path.ChangeExtension(opts.Output, ".xml"), xml);


        }
    }

}
