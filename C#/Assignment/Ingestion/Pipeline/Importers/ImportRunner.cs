using Ingestion.Pipeline.Abstractions;
using Ingestion.Pipeline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingestion.Pipeline.Importers
{
    public static class ImportRunner
    {
        public static List<Book> ImportAll(string rootPath)
        {
            List<Book> books = new List<Book>();

            foreach (string file in Directory.EnumerateFiles(rootPath, "*.*", SearchOption.AllDirectories))
            {
                string? ext = Path.GetExtension(file);
                

                if(ext == ".txt")
                {
                    JsonBookImporter jsonBookImporter = new JsonBookImporter();

                    foreach (Book book in jsonBookImporter.Import(file))
                    {
                        books.Add(book);
                    }
                }else if(ext == ".csv")
                {
                    CsvBookImporter csvBookImporter = new CsvBookImporter();

                    foreach (Book book in csvBookImporter.Import(file))
                    {
                        books.Add(book);
                    }
                }
                
            }

            return books;
        }
    }

}
