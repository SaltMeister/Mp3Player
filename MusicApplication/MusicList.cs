using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication
{
    internal class MusicList
    {
        // Controls music playlist
        // For next song / prev song
        // Check song data
        public List<List<string>> musicFileNames;
        public int itr = 0;
        public string currentSongFileName;
        // Initializing class
        public MusicList(MusicPlayer player) 
        {
            musicFileNames = new List<List<string>>();
            Console.WriteLine("Created new music List");
        }
        // Add folder music into list
        public void AddDirectoryMusic(DirectoryInfo d) 
        {
            //Console.WriteLine(d);
            // Access all mp3 files in directory
            FileInfo[] Files = d.GetFiles("*.mp3");
            // Access Each file
            foreach(FileInfo file in Files) 
            {
                //Console.WriteLine(@d+@"\"+file.Name);
                musicFileNames.Add(new List<string>{file.Name, d.ToString()});
            }
            Console.WriteLine(musicFileNames.Count + " Songs Total in queue");
            
        }

        // Return current song title.
        public string CurrentSongName() 
        {
            if (musicFileNames.Count == 0)
                return null;

            return musicFileNames[itr][0];
        }
        // Get Song image data TagLib.IPicture.
        public TagLib.File CurrentSongPic() 
        {
            var tag = TagLib.File.Create(CurrentSongDirectory() + @"\" + CurrentSongName());
            // Get tag data
            if (tag.Tag.Pictures.Length >= 1)
                return tag;
            return tag;
        }
        // Get Song Directory
        public string CurrentSongDirectory() 
        {
            if (musicFileNames.Count == 0)
                return null;

            return musicFileNames[itr][1];
        }
        // Check if there is a list to play music from.
        public bool IsPlaylist() 
        {
            if(musicFileNames.Count == 0)
                return false;

            return true;
        }
        // Next in list
        public void NextSong() 
        {
            itr++;
            // Reset itr if end of list of songs.
            if (itr >= musicFileNames.Count) 
                itr = 0;
        }

        // Go back on list
        public void PrevSong() 
        {
            itr--;
            if (itr < 0)
                itr = musicFileNames.Count-1;
        }

        // Empty list
        public void ClearList() 
        {
            musicFileNames.Clear();
        }


    }
}
