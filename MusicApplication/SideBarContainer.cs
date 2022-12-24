using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MusicApplication
{
    internal class Container : Control
    {
        private bool isActive = false;

        private Rectangle body = new Rectangle();
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
            this.Dock = DockStyle.Left;
            this.Location = new Point(0, 0);
            this.Size = size;
            //this.BackColor = Color.FromArgb(238, 196, 153);
            Console.WriteLine("New Container Created");

            SetupContainer();
        }

        // Create the Rectangle and initialize the containers
        private void SetupContainer() 
        {
            // Create Graphics
            using (Graphics g = this.CreateGraphics()) 
            {
                body.X = ClientRectangle.X;
                body.Y = ClientRectangle.Y;
                body.Width = ClientRectangle.Width;
                body.Height = ClientRectangle.Height;
            }
        }

        // Draw components
        protected override void OnPaint(PaintEventArgs e)
        {
            // Draw Background of the box
            e.Graphics.DrawRectangle(new Pen(Color.Red, 1), body);
            e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), body);
        }

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
