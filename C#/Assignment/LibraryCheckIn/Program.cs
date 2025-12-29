using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace LibraryCheckIn.Domain
{

    public class Program
    {
        enum BookCondition { New = -1, Good = 0, Worn = 3, Damaged = 10 , Notgiven = 1};

        class Book
        {
            // private = Only access by the class
            public int Id { get; set; }

            public string Title { get; set; }

            // public =  Condition can be change by others
            public BookCondition Condition { get; set; }

            public string Author { get; set; }

            public Book() { }

            public Book(int a,string b,string d, BookCondition c)
            {
                Id = a;
                Title = b;
                Condition = c;
                Author = d;
            }

            public void display()
            {
                Console.WriteLine(Id+" "+Title+" "+Condition+" "+Author);
            }
        }


        public static void Main(string[] args)
        {
            string filePath = "returns_20251010.csv";

            List<Book> books = new List<Book>();

            //using (var reader = new StreamReader(filePath))
            //{
                //using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                //{
                //    var records = csv.GetRecords<Book>();

                //    foreach (var book in records)
                //    {
                //        books.Add(book);
                //    }
                //}
            //}

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var arr = line.Split(',');
                if (arr.Length < 4)
                {

                    Book book1 = new Book();

                    if (arr.Length >= 1)
                    {
                        book1.Id = Convert.ToInt32(arr[0]);
                    }

                    if (arr.Length >= 2)
                    {
                        book1.Title = arr[1];
                    }

                    if (arr.Length >= 3)
                    {
                        book1.Author = arr[2];
                    }

                    books.Add(book1);
                    continue;
                }

                if (string.IsNullOrEmpty(arr[3]))
                {
                    Book book1 = new Book(Convert.ToInt32(arr[0]), arr[1], arr[2], BookCondition.Notgiven);

                    books.Add(book1);
                    continue;
                }

                BookCondition bookCondition = new BookCondition();

                Enum.TryParse<BookCondition>(arr[3],out bookCondition);

                Book book = new Book(Convert.ToInt32(arr[0]), arr[1], arr[2], bookCondition);

                books.Add(book);
            }

            books.ForEach(b => b.display());


            //OUTPUT

            var timestamp = DateTime.Now;
            var timestampstr = timestamp.ToString("yyyyMMdd");

            int totalReturns = books.Count;

            var countsByCondition = 
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

            string outFileName =
                $"./out/daily_summary_{timestampstr}.txt";

            using var writer = new StreamWriter(outFileName);

            writer.WriteLine($"Processed: {timestamp}");
            writer.WriteLine($"Total returns: {totalReturns}");
            writer.WriteLine();
            writer.WriteLine("Counts by condition:");

            foreach (var kv in countsByCondition)
                writer.WriteLine($"  {kv.Key}: {kv.Value}");

            writer.WriteLine();
            writer.WriteLine("Top 5 titles by penalty (desc):");

            foreach (var entry in top5)
                writer.WriteLine($"  {entry.Summary} — Penalty {entry.Score}");

            writer.Close();

        }
    }
}