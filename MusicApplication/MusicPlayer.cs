using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MusicApplication
{
    public partial class MusicPlayer : Form
    {
        private FolderBrowserDialog folderBrowserDialog1;

        private string selectedPath;
        private DirectoryInfo d;
        // Initialize new class for the music list to be used.
        private MusicList musicList;

        // Sound variables
        //-
        private bool isPlaying = false;
        public MusicPlayer()
        {
            InitializeComponent();
            musicList = new MusicList(this);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                            axWindowsMediaPlayer1.URL = @d + @"\" + musicList.CurrentSongName();
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
                    SongTimer.Enabled = false;
                    axWindowsMediaPlayer1.Ctlcontrols.pause();
                    Console.WriteLine("pause song");
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
            Console.WriteLine("Open the folder");
            this.folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                this.selectedPath = folderBrowserDialog1.SelectedPath;
                Console.WriteLine(selectedPath);
                // Set Directory Path
                d = new DirectoryInfo(this.selectedPath);

                // Call MusicList to add music to it.
                musicList.AddDirectoryMusic(d);
            }
                
        }

        // Play next song in music List.
        private void NextButton_Click(object sender, EventArgs e)
        {
            musicList.NextSong();
            // Media player play audio
            Console.WriteLine("Play Music from : " + d + musicList.CurrentSongName());
            try
            {
                axWindowsMediaPlayer1.URL = @d + @"\" + musicList.CurrentSongName();
                SetSongLabelName();
                isPlaying = true;
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

        private void axWindowsMediaPlayer1_OpenStateChange(object sender, AxWMPLib._WMPOCXEvents_OpenStateChangeEvent e)
        {
            // Change total duration text on change
            try
            {
                TotalDurationLabel.Text = axWindowsMediaPlayer1.currentMedia.durationString;
                Console.WriteLine(axWindowsMediaPlayer1.currentMedia.duration);
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

        private void UpdateSongTimers() 
        {
            CurrentDurationLabel.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
        }
        // Function for setting song information onto screen.
    }
}
