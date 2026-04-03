using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace LibraryCheckIn.Domain
{
    /// <summary>
    /// Entry point of project
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "returns_20251010.csv";

            List<Book> books = new List<Book>();

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines.Skip(1))
            {
                string[] arr = line.Split(',');

                enumBookCondition bookCondition = new enumBookCondition();
                Enum.TryParse<enumBookCondition>(arr[3],out bookCondition);
                Book book = new Book(Convert.ToInt32(arr[0]), arr[1], arr[2], bookCondition);

                books.Add(book);
            }

            books.ForEach(b => b.display());


            //OUTPUT

            DateTime timestamp = DateTime.Now;
            string timestampstr = timestamp.ToString("yyyyMMdd");

            int totalReturns = books.Count;

            Dictionary<enumBookCondition, int> countsByCondition = 
                books
                .GroupBy(b => b.Condition)
                .ToDictionary(g => g.Key, g => g.Count());

            var scoredBooks = books
               .Select(b => new
               {
                   Book = b,
                   Summary = $"{b.Title} by {b.Author}",
                   Score = Math.Clamp((int)b.Condition, 0, 100)
               })
               .OrderByDescending(x => x.Score)
               .ToList();

            var top5 = scoredBooks.Take(5).ToList();

            //Directory.CreateDirectory("./out");
            //Console(Directory.GetDirectories("out"));

            string outFileName =$"./out/daily_summary_{timestampstr}.txt";

            using (StreamWriter writer = new StreamWriter(outFileName))
            {

                writer.WriteLine($"Processed: {timestamp}");
                writer.WriteLine($"Total returns: {totalReturns}");
                writer.WriteLine();
                writer.WriteLine("Counts by condition:");

                foreach (var kv in countsByCondition)
                {
                    writer.WriteLine($"  {kv.Key}: {kv.Value}");
                }

                writer.WriteLine();
                writer.WriteLine("Top 5 titles by penalty (desc):");

                foreach (var entry in top5)
                {
                    writer.WriteLine($"  {entry.Summary} — Penalty {entry.Score}");
                }
            }
        }
    }
}