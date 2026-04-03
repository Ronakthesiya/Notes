using SecureNotes.Service;
using System.Data.SqlTypes;
using System.Text;
using System.Text.Json.Nodes;

namespace SecureNotes
{
    /// <summary>
    /// Entry point and main class
    /// </summary>
    public class Program
    {
        public static void Main(string[] args) {

            var crypto = new CryptoService();
            string passphrase = "asdfasdf";

            while (true)
            {
                Console.WriteLine("1. Create new Note");
                Console.WriteLine("2. Read Note");
                Console.WriteLine("3. Update Note");
                Console.WriteLine("4. Delete Note");
                Console.Write("Enter 1, 2, 3, 4 : ");

                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        CreateNote(crypto,passphrase);
                        break;
                    case 2:
                        Console.WriteLine(ReadNote(crypto, passphrase));
                        break;
                    case 3:
                        UpdateNote(crypto, passphrase);
                        break;
                    case 4:
                        Console.WriteLine(DeleteNote());
                        break;
                    default:
                        return;

                }

                Console.ReadKey();
                Console.Clear();
            }

        }

        public static string DeleteNote()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            string path = "./vault/" + title + ".txt";

            if (File.Exists(path))
            {
                File.Delete(path);
                return "note deleted";
            }   
            else
            {
                return "no note found";
            }
        }

        public static void CreateNote(CryptoService crypto,string passphrase)
        {
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";
            Console.Write("Body: ");
            string body = Console.ReadLine() ?? "";

            if (!IsValid(title, body))
            {
                Console.WriteLine("Enter valid data");
                return;
            }


            string path = "./vault/" + title + ".txt";

            if (File.Exists(path))
            {
                Console.WriteLine("Note with same Title already Exsist ");
                return;
            }


            byte[] salt = crypto.GenerateSalt();
            byte[] key = crypto.GenerateKey(passphrase, salt);
            byte[] iv;
            string cipher = crypto.Encrypt(body, key,out iv);

            Note note = new Note() 
            {
                Id = Guid.NewGuid(),
                Title = title,
                Body = cipher,
                Salt = Convert.ToBase64String(salt),
                IV = Convert.ToBase64String(iv),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            string jsonNote = JsonService.NotetoJson(note);
            FileService.Write(path, jsonNote);
        }


        public static string ReadNote(CryptoService crypto, string passphrase)
        {

            try
            {
                Console.Write("Title: ");
                string title = Console.ReadLine() ?? "";

                string path = "./vault/" + title + ".txt";

                if (!File.Exists(path))
                {
                    return "Note not found";
                }

                string jsontxt = FileService.Read(path);

                Note note = JsonService.JsontoNote(jsontxt);

                byte[] salt = Convert.FromBase64String(note.Salt);
                byte[] iv = Convert.FromBase64String(note.IV);
                string cipher = note.Body;

                byte[] key = crypto.GenerateKey(passphrase, salt);
                string body = crypto.Decrypt(cipher, key, iv);

                return body;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }


        public static void UpdateNote(CryptoService crypto, string passphrase)
        {

            try
            {
                Console.Write("Title: ");
                string title = Console.ReadLine() ?? "";

                string path = "./vault/" + title + ".txt";

                if (!File.Exists(path))
                {
                    Console.WriteLine("note not found");
                    return;
                }

                string jsontxt = FileService.Read(path);

                Note note = JsonService.JsontoNote(jsontxt);

                byte[] salt = Convert.FromBase64String(note.Salt);
                byte[] iv = Convert.FromBase64String(note.IV);
                string cipher = note.Body;

                byte[] key = crypto.GenerateKey(passphrase, salt);
                string body = crypto.Decrypt(cipher, key, iv);

                Console.WriteLine("Old Body");
                Console.WriteLine(body);

                Console.Write("Enter New Body: ");
                body = Console.ReadLine() ?? "";

                key = crypto.GenerateKey(passphrase, salt);
                cipher = crypto.Encrypt(body, key, out iv);

                Note newNote = new Note()
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Body = cipher,
                    Salt = Convert.ToBase64String(salt),
                    IV = Convert.ToBase64String(iv),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                string jsonNote = JsonService.NotetoJson(newNote);
                path = "./vault/" + title + ".txt";
                FileService.Write(path, jsonNote);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public static bool IsValid(string title,string body)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(body)) return false;
            return true;
        }
    }



}