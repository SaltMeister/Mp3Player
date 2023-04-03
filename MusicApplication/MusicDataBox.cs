using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MusicApplication
{
    internal class MusicDataBox : Panel
    {
        private Label titleLabel;
        private Label artistLabel;


        private int indexOfSong;

        // CREATE MUSIC BOX WITH SPECIFIED INDEX OF THE SONG IN LIST.
        public MusicDataBox(int i,Size size, List<string> x) 
        {
            this.BackColor = Color.GhostWhite;
            this.Location= new Point(0, 0);
            this.Size = size;

            // Need error detection
            var tag = TagLib.File.Create(x[1] + @"\" + x[0]);

            this.titleLabel = new Label();
            this.titleLabel.Text = tag.Tag.Title;
            this.titleLabel.Size = new Size(400, 40);
            this.titleLabel.Location = new Point(0, 0);
            this.titleLabel.Font = new Font("Cambria", 17, FontStyle.Regular);
            this.titleLabel.Parent = this;
            this.titleLabel.BackColor = Color.Transparent;

            this.artistLabel = new Label();
            // Artists
            this.artistLabel.Text = tag.Tag.FirstPerformer;
            this.artistLabel.Size = new Size(400, 30);
            this.artistLabel.Location = new Point(20, 41);
            this.artistLabel.Font = new Font("Cambria", 10, FontStyle.Italic);
            this.artistLabel.Parent = this;
            this.artistLabel.BackColor = Color.Transparent;
            
            titleLabel.BringToFront();

            // Set song index.
            this.indexOfSong = i;
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
            Console.WriteLine("Update Box Size");
            //this.Size = new Size(Parent.Width, 80);
        }
        protected void SongSelected(SelectedSongEventArgs e)
        {
            Console.WriteLine("BOX CLICKED PASSING EVENT");
            SelectedSongEventArgs args = new SelectedSongEventArgs();
            args.SongIndex = this.indexOfSong;
        }
    }
}
