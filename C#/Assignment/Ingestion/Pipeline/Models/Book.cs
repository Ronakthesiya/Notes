using Ingestion.Pipeline.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Models
{
    public enum enumBookCondition { New = -1, Good = 1, Worn = 3, Damaged = 10, Notgiven = 0 };

    public sealed class Book
    {
        public string Id { get; set; }
        public string Title { get; init; } = "";
        public string Author { get; init; } = "";
        public enumBookCondition Condition { get; init; } = enumBookCondition.Notgiven;
    }

    public class WriteObj
    {
        public int Total { get; set; }
        public List<Book> TopPenalties { get; set; }
        public List<string> Conditions { get; set; }

    }
}
