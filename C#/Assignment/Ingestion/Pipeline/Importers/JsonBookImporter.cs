using Ingestion.Pipeline.Abstractions;
using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    public sealed class JsonBookImporter : FileImporter<Book>
    {
        public override IEnumerable<Book> Import(string path)
        {
            string? json = File.ReadAllText(path);
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter() }
            };
            return JsonSerializer.Deserialize<List<Book>>(json,options) ?? Enumerable.Empty<Book>();
        }
    }

}
