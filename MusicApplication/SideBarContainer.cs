using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection.Emit;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace MusicApplication
{
    internal class Container : Control
    {
        public event EventHandler<SelectedSongEventArgs> songSelected;
        private bool isActive = false;
        private Panel container = new Panel();
        // DIM ALL BACKGROUND
        // Show 3 boxes
        // ALL SONGS,
        // ALBUMS
        // Folders
        // When one is clicked display
        // their contents to the right

        // Initialize Control
        public Container(Size size) 
        {
            this.Location = new Point(0, 0);
            this.Size = size;

            this.BackColor = Color.ForestGreen;//Color.FromArgb(238, 196, 153);

            container.AutoSize = false;
            container.AutoScroll = false;
            container.HorizontalScroll.Enabled = false;
            container.HorizontalScroll.Visible = false;
            container.HorizontalScroll.Maximum = 0;
            container.VerticalScroll.Enabled = true;
            container.VerticalScroll.Visible = true;
            Console.WriteLine("New Container Created");
        }
        public void DisplayMusicList(List<List<string>> x) //List<List<string>> x
        {
            int i = 0;
            int offset = 0;
            Console.WriteLine(x.Count);
            foreach(List<string> pair in x) 
            {
                MusicDataBox musicData = new MusicDataBox(i, new Point(0, offset), pair);
                this.Controls.Add(musicData);
                musicData.Parent = this;
                i++;
                offset += 50;
            }
            // Create music data box that when clicked creates
            // an event in MUSIC PLAYER to change the current song
            // to the selcted index

        }
        // Toggle Display for the Panel
        public void ToggleActive() 
        {   
            // Inverse current value
            isActive = !isActive;

            if (isActive)
                this.Hide();
            else
                this.Show();
        }

        // EVENT WHEN ONE OF THE DISPLAYED SONGS ARE 
        private void OnSongSelected(object sender, SelectedSongEventArgs e) 
        {
            Console.WriteLine("SONG SELECTED - =" + e.SongIndex);
        }
    }
}
