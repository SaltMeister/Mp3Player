using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MusicApplication
{
    internal class SongSlider : Control
    {
        private int trackWidth;
        private int trackHeight;
        
        private Rectangle fillRectangle = new Rectangle();
        private Rectangle trackRectangle = new Rectangle();
        private Rectangle thumbRectangle = new Rectangle();

        private float value = 0;
        private float maxValue = 100;

        private bool isEnabled = false;

        private bool thumbClicked = false;
        private TrackBarThumbState thumbState =
            TrackBarThumbState.Normal;

        public SongSlider(Size trackBarSize)
        {
            this.Location = new Point(100, 100);
            this.Size = trackBarSize;
            this.BackColor = Color.DarkCyan;

            this.DoubleBuffered = true;

            this.trackWidth = ClientRectangle.Width - 20;
            this.trackHeight = 5;
            // Calculate the initial sizes of the bar, 
            // thumb and ticks.
            SetupTrackBar();
        }

        // Calculate the sizes of the bar, thumb, and ticks rectangle.
        private void SetupTrackBar()
        {
            if (!TrackBarRenderer.IsSupported)
                return;

            using (Graphics g = this.CreateGraphics())
            {
                // Set up size of the fill rectangle.
                fillRectangle.X = ClientRectangle.X + 10;
                fillRectangle.Y = ClientRectangle.Y + 15;
                fillRectangle.Width = 0;
                fillRectangle.Height = trackHeight;

                // Calculate the size of the track bar.
                trackRectangle.X = ClientRectangle.X + 10;
                trackRectangle.Y = ClientRectangle.Y + 15;
                trackRectangle.Width = trackWidth;
                trackRectangle.Height = trackHeight;

                // Calculate the size of the thumb.
                thumbRectangle.Size =
                    TrackBarRenderer.GetTopPointingThumbSize(g,
                    TrackBarThumbState.Normal);

                thumbRectangle.X = ClientRectangle.X + 10;
                thumbRectangle.Y = trackRectangle.Y - 7;
            }
        }

        // Draw the track bar.
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            {
                this.Parent.Text = "CustomTrackBar Disabled";
                return;
            }

            this.Parent.Text = "CustomTrackBar Enabled";
            TrackBarRenderer.DrawHorizontalTrack(e.Graphics,
                trackRectangle);

            // Render the fill rectangle.
            e.Graphics.DrawRectangle(new Pen(Color.Green, 0), fillRectangle);
            e.Graphics.FillRectangle(new SolidBrush(Color.Green), fillRectangle);

            TrackBarRenderer.DrawVerticalThumb(e.Graphics,
                thumbRectangle, thumbState);

/*            TrackBarRenderer.DrawHorizontalTicks(e.Graphics,
                ticksRectangle, numberTicks, EdgeStyle.Raised);*/
        }
        private void MoveFillBarToThumb() 
        {
            fillRectangle.Width = thumbRectangle.X;
        }
        private void UpdateValue() 
        {
            // Value equal to percent of the bar.
            value = thumbRectangle.X / (float)trackRectangle.Width;
            Console.WriteLine(value);
        }
        private void MoveThumb(int x) 
        {
            if (x > trackRectangle.X && x < trackRectangle.Width)
                thumbRectangle.X = x;
        }
        // Determine whether the user has clicked the track bar thumb.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;
            if (!isEnabled)
                return;
            // Check if mouse position is on the slider
            if (this.thumbRectangle.Contains(e.Location))
            {
                thumbClicked = true;
                thumbState = TrackBarThumbState.Pressed;
            }
            // Handle moving thumb rectangle to wherever user selects.
            else if (ClientRectangle.Contains(e.Location)) 
            {
                //thumbRectangle.X = e.X - 5;
                MoveThumb(e.X);
                UpdateValue();
                MoveFillBarToThumb();
            }

            this.Invalidate();
        }

        // Redraw the track bar thumb if the user has moved it.
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
            return;
            if (!isEnabled)
                return;
            if (thumbClicked == true)
            {
                //Console.WriteLine(e.X);
                if (e.Location.X > trackRectangle.X &&
                    e.Location.X < (trackRectangle.X +
                    trackRectangle.Width))
                {
                    thumbClicked = false;
                    thumbState = TrackBarThumbState.Hot;
                    this.Invalidate();
                }

                thumbClicked = false;
            }
        }

        // Track cursor movements.
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!TrackBarRenderer.IsSupported)
                return;
            if (!isEnabled)
                return;
            // The user is moving the thumb.
            if (thumbClicked == true)
            {
                MoveThumb(e.X);
                UpdateValue();
                MoveFillBarToThumb();
            }

            // The cursor is passing over the track.
            else
            {
                thumbState = thumbRectangle.Contains(e.Location) ?
                    TrackBarThumbState.Hot : TrackBarThumbState.Normal;
            }


            Invalidate();
        }


        // Public Methods
        // Call to update slide for song
        public void SetValue(float currentDuration, float totalDuration)
        {
            // Get Percentage of input
            float percent;

            percent = currentDuration / totalDuration;
            percent = percent * (float)trackRectangle.Width;

            MoveThumb((int)percent);
            MoveFillBarToThumb();

            Console.WriteLine(percent);
        }
        public void Enable() 
        {
            isEnabled = true;
        }
        public void Disable() 
        {
            isEnabled = false;
        }
        // Reset to default position on slider
        public void Reset() 
        {
            value = 0;
            thumbRectangle.X = ClientRectangle.X + 10;
            MoveFillBarToThumb();
        }
        public float GetValue() 
        {
            return value;
        }
    }
}
