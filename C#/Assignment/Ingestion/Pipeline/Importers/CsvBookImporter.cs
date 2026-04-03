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
    /// Marked sealed: extension is not intended because CSV parsing logic
    /// is tightly coupled to this specific file structure.
    /// </summary>
    public sealed class CsvBookImporter : FileImporter<Book>
    {
        public override List<Book> Import(string path)
        {
            List<Book> books = new List<Book>();

            foreach (string line in File.ReadLines(path).Skip(1))
            {
                string[]? parts = line.Split(',');

                enumBookCondition bookCondition = new enumBookCondition();

                Enum.TryParse<enumBookCondition>(parts[3],out bookCondition);

                books.Add(new Book
                {
                    Id = parts[0],
                    Title = parts[1],
                    Author = parts[2],
                    Condition = bookCondition
                });
            }

            return books;
        }
    }

}
