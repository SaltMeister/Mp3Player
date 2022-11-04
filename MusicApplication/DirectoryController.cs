using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    internal class DirectoryController
    {
        string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //string readFileDirectory = documentPath;
        public DirectoryController() 
        {
            Console.WriteLine(documentPath);
            Console.WriteLine("Directory Controller Created");
            CheckForProgramFolder();
            CheckForDirectoryFile();
            // Update directory path.
            documentPath += @"\\MP3Player\directory.txt";


        }
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

        //private 
    }
}
