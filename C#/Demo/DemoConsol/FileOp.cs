using System;

namespace DemoConsol
{
    public class FileOp
    {
        public static void demo()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== FILE OPERATIONS MENU =====");
                Console.WriteLine("1. Create File");
                Console.WriteLine("2. Write Text to File");
                Console.WriteLine("3. Append Text to File");
                Console.WriteLine("4. Read File");
                Console.WriteLine("5. Copy File");
                Console.WriteLine("6. Move File");
                Console.WriteLine("7. Delete File");
                Console.WriteLine("8. Check if File Exists");
                Console.WriteLine("9. Read All Lines");
                Console.WriteLine("10. Write All Lines");
                Console.WriteLine("11. File Details");

                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateFile();
                        break;
                    case "2":
                        WriteText();
                        break;
                    case "3":
                        AppendText();
                        break;
                    case "4":
                        ReadFile();
                        break;
                    case "5":
                        CopyFile();
                        break;
                    case "6":
                        MoveFile();
                        break;
                    case "7":
                        DeleteFile();
                        break;
                    case "8":
                        CheckExists();
                        break;
                    case "9":
                        ReadAllLines();
                        break;
                    case "10":
                        WriteAllLines();
                        break;
                    case "11":
                        FileDetails();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void CreateFile()
        {
            Console.Write("Enter file name to create: ");
            string path = Console.ReadLine();
            using (FileStream fs = File.Create(path))
            {
                Console.WriteLine($"File '{path}' created successfully.");
            }
        }

        static void WriteText()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter text to write: ");
            string text = Console.ReadLine();
            File.WriteAllText(path, text);
            Console.WriteLine("Text written successfully.");
        }

        static void AppendText()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter text to append: ");
            string text = Console.ReadLine();
            File.AppendAllText(path, text);
            Console.WriteLine("Text appended successfully.");
        }

        static void ReadFile()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.WriteLine("\nFile Content:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        static void CopyFile()
        {
            Console.Write("Enter source file path: ");
            string source = Console.ReadLine();
            Console.Write("Enter destination file path: ");
            string destination = Console.ReadLine();
            File.Copy(source, destination, overwrite: true);
            Console.WriteLine("File copied successfully.");
        }

        static void MoveFile()
        {
            Console.Write("Enter source file path: ");
            string source = Console.ReadLine();
            Console.Write("Enter destination file path: ");
            string destination = Console.ReadLine();
            File.Move(source, destination, overwrite: true);
            Console.WriteLine("File moved successfully.");
        }

        static void DeleteFile()
        {
            Console.Write("Enter file path to delete: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                File.Delete(path);
                Console.WriteLine("File deleted successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        static void CheckExists()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.WriteLine(File.Exists(path) ? "File exists." : "File does not exist.");
        }

        static void ReadAllLines()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine("\nFile Lines:");
                foreach (var line in lines)
                    Console.WriteLine(line);
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        static void WriteAllLines()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter lines (type 'END' to stop):");

            var lines = new List<string>();
            string input;
            while ((input = Console.ReadLine())?.ToUpper() != "END")
            {
                lines.Add(input);
            }

            File.WriteAllLines(path, lines);
            Console.WriteLine("Lines written successfully.");
        }

        static void FileDetails()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();

            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("full name : " + fileInfo.FullName);
            Console.WriteLine("name : " + fileInfo.Name);
            Console.WriteLine("Length : " + fileInfo.Length);
            Console.WriteLine("CreationTime : " + fileInfo.CreationTime);
            Console.WriteLine("Directory : " + fileInfo.Directory);
            Console.WriteLine("Directory Name : " + fileInfo.DirectoryName);
            Console.WriteLine("Extension : " + fileInfo.Extension);
            Console.WriteLine("LastAccessTime : " + fileInfo.LastAccessTime);
            Console.WriteLine("LastWriteTime : " + fileInfo.LastWriteTime);
        }
    }
}
