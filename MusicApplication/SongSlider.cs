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

        private bool isEnabled = true;

        private bool thumbClicked = false;
        private TrackBarThumbState thumbState =
            TrackBarThumbState.Normal;

        public event EventHandler<PlayerValueChangedEventArgs> valueChanged;

        private EventHandler thumbChanged;
        public event EventHandler ThumbChanged 
        {
            add {
                thumbChanged += value;
            }
            remove {
                thumbChanged -= value;
            }
        }
        public SongSlider(Size trackBarSize)
        {
            this.Location = new Point(108, 17);
            this.Size = trackBarSize;
            this.BackColor = Color.DarkCyan;

            this.DoubleBuffered = true;

            this.trackWidth = ClientRectangle.Width - 20;
            this.trackHeight = 5;
            // Calculate the initial sizes of the bar, 
            // thumb and ticks.
            SetupTrackBar();
        }
        //protected override void 
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

        // Move the Fill color to the thumb position.
        private void MoveFillBarToThumb() 
        {
            fillRectangle.Width = thumbRectangle.X;
        }

        // Update Value based on user Input.
        private void UpdateValue() 
        {
            // Value equal to percent of the bar.
            this.value = ( (thumbRectangle.X - 6)/ (float)trackRectangle.Width) * 100;


            if (value > 100)
                value = 100;
            else if (value < 0)
                value = 0;
            PlayerValueChangedEventArgs args = new PlayerValueChangedEventArgs();
            ValueChanged(args);

            args.NewValue = value;

           // thumbChanged?.Invoke(this, );
            Console.WriteLine("New Value set to: " + value + " / 100");
        }
        // VALUE CHANGED EVENT FOR THE SLIDER VALUE
        protected void ValueChanged(PlayerValueChangedEventArgs e) 
        {
            Console.WriteLine("Event CALLED");
            EventHandler<PlayerValueChangedEventArgs> handler = valueChanged;
            if (handler != null)
                handler(this, e);
        }
        // Move thumb to given X position on screen.
        private void MoveThumb(int x) 
        {
            Console.WriteLine("Move to: " + x + " from " + trackRectangle.X + " - " + (trackRectangle.Width + trackRectangle.X));
            if (x > trackRectangle.X && x < trackRectangle.Width + trackRectangle.X)
                thumbRectangle.X = x - 5;
            else if (x < trackRectangle.X) 
            {
                Console.WriteLine("Lock to left");
                Reset();
            }
            else
                Console.WriteLine("Out Of Range of: " + trackRectangle.X + " - " + (trackRectangle.Width + trackRectangle.X));
        }
        /* Summary */
        // Event Handlers For the Slider.
        // Moves the thumb bar to wherever use clicks on the slider.
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
                MoveThumb(e.X);
                MoveFillBarToThumb();
                UpdateValue();
                thumbChanged?.Invoke(this, e);
            }

            this.Invalidate();
        }

        // 
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
                    e.Location.X < (trackRectangle.X + trackRectangle.Width))
                {
                    thumbClicked = false;
                    thumbState = TrackBarThumbState.Hot;
                    thumbChanged?.Invoke(this, e);
                    this.Invalidate();
                }
                // Call event thumb changed

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
        /* End Of  */
        /* Summary */


        // Public Methods
        // Set value to percentage out of 100
        public void SetValue(float currentDuration, float totalDuration)
        {
            //Console.WriteLine(currentDuration + " " + totalDuration);
            // Get Percentage of input
            float percent;
            percent = currentDuration / totalDuration;

            this.value = percent * 100;
            //Console.WriteLine(percent + " --> " + value);
            this.Invalidate();
            MoveFillBarToThumb();
        }
        public void MoveSliderToValue() 
        {
            //Console.WriteLine("Adjust Slider to new value");
            float positionOnTrack = trackRectangle.Width * (this.value / 100);
            thumbRectangle.X = trackRectangle.X + (int)positionOnTrack;
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
            MoveSliderToValue();
            MoveFillBarToThumb();
        }
        public float GetValue() 
        {
            return value;
        }
    }
}
