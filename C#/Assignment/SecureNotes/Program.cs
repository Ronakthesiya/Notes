using SecureNotes.Service;

namespace SecureNotes
{
    public class Program
    {
        public static void Main(string[] args) {

            while (true)
            {
                Console.WriteLine("1. Create new Note");
                Console.WriteLine("2. Read Note");
                Console.Write("Enter 1 or 2 : ");

                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:

                        Console.Write("Enter Title : ");
                        string title = Console.ReadLine();
                        Console.Write("Enter note : ");
                        string body = Console.ReadLine();

                        WritetoNote(title, body);

                        break;

                    case 2:
                        Console.Write("Enter Title : ");
                        string title2 = Console.ReadLine();

                        Console.WriteLine(ReadNote(title2));

                        break;
                    default:
                        return;
                        break;

                }
            }

        }

        public static void WritetoNote(string Title,string Body)
        {
            Note note = new Note();
            note.Title = Title;

            string newKey = CryptoService.GenerateKey();
            string newIV;

            note.Body = CryptoService.Encrypt(Body, newKey, out newIV);

            note.IV = newIV;
            note.key = newKey;

            string jsonNote = JsonService.NotetoJson(note);

            string path = "./vault/"+Title+".txt";

            FileService.Write(path, jsonNote);
        }

        public static string ReadNote(string Title)
        {
            string path = "./vault/" + Title + ".txt";

            string jsontxt = FileService.Read(path);

            Note note = JsonService.JsontoNote(jsontxt);

            string body = CryptoService.Decrypt(note.Body, note.key, note.IV);

            return body;
        }
    }
}