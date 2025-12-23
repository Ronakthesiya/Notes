using Ingestion.Pipeline.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Models
{
    public sealed class Book
    {
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
        public int Year { get; init; }
        public decimal Penalty { get; init; }
        public string Condition { get; init; } = "";
    }

    public class WriteObj
    {
        public WriteObj()
        {
            
        }
        public int Total { get; set; }
        public List<Book> TopPenalties { get; set; }
        public List<ConditionCount> Conditions { get; set; }

    }
}
