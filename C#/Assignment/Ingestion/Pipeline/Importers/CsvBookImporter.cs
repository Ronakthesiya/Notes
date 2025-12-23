using Ingestion.Pipeline.Abstractions;
using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    /// <summary>
    /// CSV importer for <see cref="Book"/> records.
    /// Marked sealed: extension is not intended because CSV parsing logic
    /// is tightly coupled to this specific file structure.
    /// </summary>
    public sealed class CsvBookImporter : FileImporter<Book>
    {
        public override List<Book> Import(string path)
        {
            List<Book> books = new List<Book>();

            foreach (var line in File.ReadLines(path).Skip(1))
            {
                var parts = line.Split(',');
                books.Add(new Book
                {
                    Title = parts[0],
                    Author = parts[1],
                    Year = int.Parse(parts[2]),
                    Penalty = decimal.Parse(parts[3]),
                    Condition = parts[4]
                });
            }

            return books;
        }
    }

}
