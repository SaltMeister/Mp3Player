﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using TagLib.IFD;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace MusicApplication
{
    public partial class MusicPlayer : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;
        private string selectedPath;

        private DirectoryInfo d;


        // Initialize new Classes that will be used.
        private MusicList musicList;
        private DirectoryController directoryController;
        private SongSlider songSlider;
        private Container musicListContainer;

        // Sound variables
        //-
        private bool isPlaying = false;
        public MusicPlayer()
        {
            directoryController = new DirectoryController();
            // Create new song Slider
            songSlider = new SongSlider(new Size(500, 50));
            songSlider.ThumbChanged += SliderValueChange;
            Controls.Add(songSlider);

            musicListContainer = new Container(new Size(300, 500));
            Controls.Add(musicListContainer);
            //MusicPicture
            d = new DirectoryInfo(@"D:\\Internet Explorer downloads\\Music");
            
            musicList = new MusicList(this);

            // SET UP COMPONENTS FOR FORMS
            InitializeComponent();


            // Setting Parents
            TotalDurationLabel.Parent = MusicControllerPanel;
            CurrentDurationLabel.Parent = MusicControllerPanel;
            songSlider.Parent = MusicControllerPanel;
            // Set Song slider position to the correct area.
            songSlider.Location = new Point(songSlider.Parent.Width / 5, 10);

            // Pass directories for music list to use.
            foreach (string directory in directoryController.GetMusicDirectoryList()) 
            {
                DirectoryInfo d = new DirectoryInfo(directory);
                if(d.Exists)
                    musicList.AddDirectoryMusic(d);
            }
            // Place after musicList is updated
            // GET MUSIC LIST 3d array.
            musicListContainer.DisplayMusicList(musicList.GetSongList());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Play / Pause current media
        private void button3_Click(object sender, EventArgs e)
        {
            // Media player play audio
            //Console.WriteLine("Play Music from : " + d + musicList.CurrentSongName());
            try
            {
                if (!isPlaying)
                {
                    isPlaying = true;
                    SongTimer.Enabled = true;
                    // start / unpause song
                    if (axWindowsMediaPlayer1.Ctlcontrols.currentItem == null)
                    {
                        Console.WriteLine("No Song currently");
                        // If MusicList exists

                        if (musicList.IsPlaylist())
                        {
                            axWindowsMediaPlayer1.URL = musicList.CurrentSongDirectory() + @"\" + musicList.CurrentSongName();
                            SetSongLabelName();
                        }
                    }
                    else // unpause song
                    {
                        Console.WriteLine("resume song");
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                }
                else if (isPlaying) 
                {
                    
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    Console.WriteLine("pause song");
                    SongTimer.Enabled = false;
                    isPlaying = false;
                }
            }
            catch 
            {
                Console.WriteLine("Directory not found");
                isPlaying = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SelectMusicFolder_HelpRequest(object sender, EventArgs e)
        {

        }

        // Intend to go to previous song
        private void PrevButton_Click_1(object sender, EventArgs e)
        {

            musicList.PrevSong();
            // Media player play audio
            Console.WriteLine("Play Music from : " + musicList.CurrentSongDirectory() + musicList.CurrentSongName());
            try
            {
                axWindowsMediaPlayer1.URL = musicList.CurrentSongDirectory() + @"\" + musicList.CurrentSongName();
                isPlaying = true;
                SongTimer.Enabled = true;
                //SetSongPlaying();
            }
            catch
            {
                Console.WriteLine("Directory not found");
                isPlaying = false;
            }
        }

        // Play next song in music List.
        private void NextButton_Click(object sender, EventArgs e)
        {
            musicList.NextSong();
            // Media player play audio
            Console.WriteLine("Play Music from : " + musicList.CurrentSongDirectory() + musicList.CurrentSongName());
            try
            {
                axWindowsMediaPlayer1.URL = musicList.CurrentSongDirectory() + @"\" + musicList.CurrentSongName();
                isPlaying = true;
                SongTimer.Enabled = true;
                //SetSongPlaying();
            }
            catch
            {
                Console.WriteLine("Directory not found");
                isPlaying = false;
            }
        }

        // Error when media play does not exist
        private void axWindowsMediaPlayer1_MediaError(object sender, AxWMPLib._WMPOCXEvents_MediaErrorEvent e)
        {
            Console.WriteLine("Could not play audio");
        }
        // Set the song label name
        private void SetSongLabelName() 
        {
            SongTitleLabel.Text = musicList.CurrentSongName();
        }
        // GET ADJUSTING SLIDER = ADJUSTING SONG POSITION
        private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            // Change total duration text on change
            try
            {
                // Ignore Calls when song length is 0.
                if (axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration == 0)
                    return;

                // Adjust the tracker to match the song.
                SetSongPlaying();
                UpdateSongTimers();
                isPlaying = true;

                // Change song image
                var tag = musicList.CurrentSongPic();
                if (tag.Tag.Pictures.Length >= 1)
                {
                    Console.WriteLine("Display Song PICTURE");
                    var bin = (byte[])(tag.Tag.Pictures[0].Data.Data);
                    // Set Song Image with the size
                    MusicPicture.Image = Image.FromStream(new MemoryStream(bin)).GetThumbnailImage(MusicPicture.Width, MusicPicture.Height, null, IntPtr.Zero);
                }
                else 
                {
                    Console.WriteLine("Song does not have image");
                    MusicPicture.Image = MusicPicture.ErrorImage;
                }
            }
            catch 
            {
                Console.WriteLine("Player not updated yet");
            }
        }

        // Function event for timer to update the progress bar and timer label of song
        private void SongTimer_Tick(object sender, EventArgs e)
        {
            UpdateSongTimers();
        }

        // Function for setting song information onto screen / Increasing updateSlider value.
        private void UpdateSongTimers() 
        {
            if (axWindowsMediaPlayer1.Ctlcontrols.currentPosition < 1)
                CurrentDurationLabel.Text = "00:00";
            else
                CurrentDurationLabel.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;

            // Set Song Slider position
            songSlider.SetValue((float)axWindowsMediaPlayer1.Ctlcontrols.currentPosition, (float)axWindowsMediaPlayer1.currentMedia.duration);
            songSlider.MoveSliderToValue();
        }

        // WHEN SLIDER BAR IS ADJUSTED CHANGE SONG TO MATCH SLIDER PERCENT.
        public void SliderValueChange(object sender, EventArgs e) 
        {
            float newPosition = (float)axWindowsMediaPlayer1.currentMedia.duration * (songSlider.GetValue()/100);

            Console.WriteLine("UPDATED SLIDER EVENT CALLED");
            Console.WriteLine(axWindowsMediaPlayer1.Ctlcontrols.currentPosition + " " + newPosition);
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = newPosition;
                        // Set Song Slider position
            songSlider.SetValue((float)axWindowsMediaPlayer1.Ctlcontrols.currentPosition, (float)axWindowsMediaPlayer1.currentMedia.duration);
            songSlider.MoveSliderToValue();
            UpdateSongTimers();
        }

        // Changed to ui when new song plays
        private void SetSongPlaying() 
        {
            // Set Song to play by default
            if (!isPlaying)
                isPlaying = true;
                isPlaying = true;
            axWindowsMediaPlayer1.Ctlcontrols.play();

            // Set Total duration
            TotalDurationLabel.Text = axWindowsMediaPlayer1.currentMedia.durationString;
            
            UpdateSongTimers();
            SetSongLabelName();
        }

        // Display Music List Box
        private void MusicListButton_Click(object sender, EventArgs e)
        {
            musicListContainer.ToggleActive();
        }

        // Extract music from selected folder
        private void MusicDirectoryButton_Click(object sender, EventArgs e)
        {
            // Folder extraction code
            Console.WriteLine("Open the folder");
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.selectedPath = folderBrowserDialog1.SelectedPath;
                //Console.WriteLine(selectedPath);
                // Set Directory Path
                d = new DirectoryInfo(this.selectedPath);
                var list = directoryController.GetMusicDirectoryList();
                
                // Don't add repeat Directories into the document file
                foreach (string i in list) 
                {
                    if (i == d.ToString())
                    {
                        Console.WriteLine("Directory already accessed in folder");
                        return;
                    }                   
                }
                // Call MusicList to add music to it.
                directoryController.AddDirectory(d.ToString());
                musicList.AddDirectoryMusic(d);
            }
        }

        private void SongTitleLabel_Click(object sender, EventArgs e)
        {

        }
    }
}   
