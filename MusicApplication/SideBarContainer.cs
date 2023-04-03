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
    internal class Container : TableLayoutPanel
    {
        public event EventHandler<SelectedSongEventArgs> songSelected;
        private bool isActive = false;
        //private TableLayoutPanel container = new TableLayoutPanel();
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
            this.Anchor= AnchorStyles.Left;

            this.BackColor = Color.ForestGreen;//Color.FromArgb(238, 196, 153);

            this.AutoScroll= true;
            //container.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            Console.WriteLine("New Container Created");
        }
        public void DisplayMusicList(List<List<string>> x) //List<List<string>> x
        {
            Size boxSize = new Size(this.Size.Width-20, 80);
            int i = 0;
            foreach (List<string> pair in x)
            {
                MusicDataBox musicData = new MusicDataBox(i, boxSize, pair);


                this.RowStyles.Add(new RowStyle(SizeType.Absolute, boxSize.Height + 10));

                this.Controls.Add(musicData, 0, i);

                musicData.Parent = this;

                this.RowCount++;
                i++;

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
