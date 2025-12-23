using Ingestion.Pipeline.Abstractions;
using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    public sealed class JsonBookImporter : FileImporter<Book>
    {
        public override IEnumerable<Book> Import(string path)
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? Enumerable.Empty<Book>();
        }
    }

}
