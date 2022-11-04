using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    internal class DirectoryController
    {
        string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath;
        HashSet<string> musicDirectorySet = new HashSet<string>();
        //string readFileDirectory = documentPath;
        public DirectoryController() 
        {
            Console.WriteLine(documentPath);
            Console.WriteLine("Directory Controller Created");
            CheckForProgramFolder();
            CheckForDirectoryFile();
            // Update directory path.
            filePath = documentPath + @"\\MP3Player\directory.txt";

            ReadFile();

            foreach (string line in musicDirectorySet) 
            {
                Console.WriteLine(line);
            }
        }
        // PUBLIC METHODS //

        // Returns list of all directories
        public List<string> GetMusicDirectoryList() 
        {
            List<string> list = new List<string>();
            foreach (string line in musicDirectorySet)
            {
                list.Add(line);
            }

            return list;
        }

        // Add given directory and write directory to list if not already within the file.
        public void AddDirectory(string path) 
        {

        }





        // PRIVATE METHODS //
        // Checks for folder in Documents if N/A, Create one.
        private void CheckForProgramFolder() 
        {
            if (Directory.Exists(documentPath + @"\MP3Player"))
            {
                Console.WriteLine("Folder Exists in directory");
                return;
            }

            // Create folder
            Directory.CreateDirectory(documentPath + @"\MP3Player");
            Console.WriteLine("Folder Created in Documents");
            return;
        }

        // Check text file in folder, if N/A, Create one.
        private void CheckForDirectoryFile() 
        {
            // Check document folder if directory.txt exists
            if (File.Exists(documentPath + @"\MP3Player\directory.txt"))
                return;

            File.Create(documentPath + @"\MP3Player\directory.txt");
            Console.WriteLine("Directory Text file Created");
            return;
        }

        private void ReadFile() 
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
                musicDirectorySet.Add(line);
            }

            // Write Directory into file
            using (StreamWriter sw = File.AppendText(filePath))
            {
                if (musicDirectorySet.TryGetValue(@"D:\\Internet Explorer downloads\\Music", out string t))
                {
                    Console.WriteLine("Directory already in file");
                }
                else
                {
                    Console.WriteLine("Added Directory to file");
                    sw.WriteLine(@"D:\\Internet Explorer downloads\\Music");
                }
                    sw.Close();
            }
        }
    }
}
