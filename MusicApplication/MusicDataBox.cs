using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MusicApplication
{
    internal class MusicDataBox : Button
    {
        private Label titleLabel;
        private Label artistLabel;
        private Label albumLabel;
        private Label durationLabel;

        private int indexOfSong;

        // CREATE MUSIC BOX WITH SPECIFIED INDEX OF THE SONG IN LIST.
        public MusicDataBox(int i, Point position, List<string> x) 
        {
            this.BackColor = Color.GhostWhite;
            this.Location = position;
            this.Size = new Size(0, 0);

            var tag = TagLib.File.Create(x[1] + @"\" + x[0]);

            this.titleLabel = new Label();
            this.titleLabel.Text = tag.Tag.Title;
            this.titleLabel.Size = new Size(50, 20);
            this.titleLabel.Location = new Point(0, 0);
            this.titleLabel.Parent = this;
            //this.artistLabel = new Label();
            //this.albumLabel = new Label();
            //this.durationLabel = new Label();

            //titleLabel.Text = "Title";
            //artistLabel.Text = "Artist";
           // albumLabel.Text = "Album";
            //durationLabel.Text = "Duration";
           
            // Set song index.
            this.indexOfSong = i;
            Console.WriteLine("NEW BOX CREATED FOR MUSIC DATA");
            // Stack 
           
            this.BringToFront();
        }

        // Get the index of the current Song.
        public int IndexOfSong 
        {
            get { return indexOfSong; }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            this.Size = new Size(Parent.Width, 45);
        }
        protected void SongSelected(SelectedSongEventArgs e)
        {
            Console.WriteLine("BOX CLICKED PASSING EVENT");
            SelectedSongEventArgs args = new SelectedSongEventArgs();
            args.SongIndex = this.indexOfSong;
        }
    }
}
