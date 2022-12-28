using System;
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
            this.BringToFront();
            this.BackColor = Color.ForestGreen;//Color.FromArgb(238, 196, 153);

            container.AutoSize = false;
            container.AutoScroll = false;
            container.HorizontalScroll.Enabled = false;
            container.HorizontalScroll.Visible = false;
            container.HorizontalScroll.Maximum = 0;
            container.VerticalScroll.Enabled = true;
            container.VerticalScroll.Visible = true;
            Console.WriteLine("New Container Created");
            Console.WriteLine(ClientRectangle.Size);
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
    }
}
