using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureNotes
{
    /// <summary>
    /// Provide File Service to write in file and read from file
    /// </summary>
    internal class FileService
    {
        public static void Write(string path,string json)
        {
            if (!Path.Exists(path))
            {
                using (File.Create(path)) { }
            }

            File.WriteAllText(path, json);
        }

        public static string? Read(string path)
        {
            if (!Path.Exists(path))
            {
                return null;
            }
            return File.ReadAllText(path);
        }
    }
}
