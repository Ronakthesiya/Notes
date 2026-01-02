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
            Options opts = new Options();

            List<Book>? books = ImportRunner.ImportAll(opts.InputDir).ToList();

            books.ForEach(Displaybook);

            WriteObj summary = new WriteObj
            {
                Total = books.Count,
                TopPenalties = books.TopBy(b => (int)b.Condition, 5).ToList(),
                Conditions = books.ToConditionCounts().ToList(),
            };

            string json = SummarySerializer.ToJson(summary);
            File.WriteAllText(opts.Output, json);

            string xml = SummarySerializer.ToXml(summary);
            File.WriteAllText(Path.ChangeExtension(opts.Output, ".xml"), xml);


        }

        public static void Displaybook(Book book)
        {
            Console.WriteLine(book.Id + " " + book.Title + " " + book.Author + " " + book.Condition);
        }
    }



}
