namespace MusicApplication
{
    partial class MusicPlayer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayer));
            this.MusicPicture = new System.Windows.Forms.PictureBox();
            this.MusicControllerPanel = new System.Windows.Forms.Panel();
            this.CurrentDurationLabel = new System.Windows.Forms.Label();
            this.MusicListButton = new System.Windows.Forms.Button();
            this.TotalDurationLabel = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.SongTitleLabel = new System.Windows.Forms.Label();
            this.SelectMusicFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SongTimer = new System.Windows.Forms.Timer(this.components);
            this.MusicDirectoryButton = new System.Windows.Forms.Button();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.MusicPicture)).BeginInit();
            this.MusicControllerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // MusicPicture
            // 
            this.MusicPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MusicPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MusicPicture.Image = ((System.Drawing.Image)(resources.GetObject("MusicPicture.Image")));
            this.MusicPicture.InitialImage = ((System.Drawing.Image)(resources.GetObject("MusicPicture.InitialImage")));
            this.MusicPicture.Location = new System.Drawing.Point(199, 9);
            this.MusicPicture.Margin = new System.Windows.Forms.Padding(0);
            this.MusicPicture.MaximumSize = new System.Drawing.Size(400, 400);
            this.MusicPicture.MinimumSize = new System.Drawing.Size(200, 200);
            this.MusicPicture.Name = "MusicPicture";
            this.MusicPicture.Size = new System.Drawing.Size(400, 400);
            this.MusicPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MusicPicture.TabIndex = 1;
            this.MusicPicture.TabStop = false;
            this.MusicPicture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MusicControllerPanel
            // 
            this.MusicControllerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.MusicControllerPanel.Controls.Add(this.CurrentDurationLabel);
            this.MusicControllerPanel.Controls.Add(this.MusicListButton);
            this.MusicControllerPanel.Controls.Add(this.TotalDurationLabel);
            this.MusicControllerPanel.Controls.Add(this.PauseButton);
            this.MusicControllerPanel.Controls.Add(this.NextButton);
            this.MusicControllerPanel.Controls.Add(this.PrevButton);
            this.MusicControllerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MusicControllerPanel.Location = new System.Drawing.Point(0, 477);
            this.MusicControllerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MusicControllerPanel.Name = "MusicControllerPanel";
            this.MusicControllerPanel.Size = new System.Drawing.Size(784, 124);
            this.MusicControllerPanel.TabIndex = 2;
            // 
            // CurrentDurationLabel
            // 
            this.CurrentDurationLabel.AutoSize = true;
            this.CurrentDurationLabel.BackColor = System.Drawing.Color.Transparent;
            this.CurrentDurationLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentDurationLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.CurrentDurationLabel.Location = new System.Drawing.Point(97, 17);
            this.CurrentDurationLabel.MaximumSize = new System.Drawing.Size(70, 20);
            this.CurrentDurationLabel.MinimumSize = new System.Drawing.Size(20, 20);
            this.CurrentDurationLabel.Name = "CurrentDurationLabel";
            this.CurrentDurationLabel.Size = new System.Drawing.Size(63, 20);
            this.CurrentDurationLabel.TabIndex = 7;
            this.CurrentDurationLabel.Text = "CurrentDurationLabel";
            this.CurrentDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MusicListButton
            // 
            this.MusicListButton.Location = new System.Drawing.Point(672, 62);
            this.MusicListButton.Name = "MusicListButton";
            this.MusicListButton.Size = new System.Drawing.Size(77, 42);
            this.MusicListButton.TabIndex = 5;
            this.MusicListButton.Text = "MusicListMenuButton";
            this.MusicListButton.UseVisualStyleBackColor = true;
            this.MusicListButton.Click += new System.EventHandler(this.MusicListButton_Click);
            // 
            // TotalDurationLabel
            // 
            this.TotalDurationLabel.AutoSize = true;
            this.TotalDurationLabel.BackColor = System.Drawing.Color.Transparent;
            this.TotalDurationLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalDurationLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.TotalDurationLabel.Location = new System.Drawing.Point(634, 17);
            this.TotalDurationLabel.MaximumSize = new System.Drawing.Size(70, 20);
            this.TotalDurationLabel.MinimumSize = new System.Drawing.Size(20, 20);
            this.TotalDurationLabel.Name = "TotalDurationLabel";
            this.TotalDurationLabel.Size = new System.Drawing.Size(63, 20);
            this.TotalDurationLabel.TabIndex = 6;
            this.TotalDurationLabel.Text = "TotalDurationLabel";
            this.TotalDurationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PauseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PauseButton.Location = new System.Drawing.Point(368, 62);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.TabIndex = 2;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NextButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.NextButton.Location = new System.Drawing.Point(498, 62);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(50, 50);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PrevButton
            // 
            this.PrevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PrevButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PrevButton.Location = new System.Drawing.Point(227, 62);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(50, 50);
            this.PrevButton.TabIndex = 0;
            this.PrevButton.Text = "Prev";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click_1);
            // 
            // SongTitleLabel
            // 
            this.SongTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SongTitleLabel.AutoEllipsis = true;
            this.SongTitleLabel.AutoSize = true;
            this.SongTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.SongTitleLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SongTitleLabel.Font = new System.Drawing.Font("Meiryo", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SongTitleLabel.Location = new System.Drawing.Point(248, 427);
            this.SongTitleLabel.MaximumSize = new System.Drawing.Size(600, 50);
            this.SongTitleLabel.MinimumSize = new System.Drawing.Size(300, 50);
            this.SongTitleLabel.Name = "SongTitleLabel";
            this.SongTitleLabel.Size = new System.Drawing.Size(300, 50);
            this.SongTitleLabel.TabIndex = 3;
            this.SongTitleLabel.Tag = "SongTitleLabel";
            this.SongTitleLabel.Text = "Song Title";
            this.SongTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SongTitleLabel.Click += new System.EventHandler(this.SongTitleLabel_Click);
            // 
            // SelectMusicFolder
            // 
            this.SelectMusicFolder.HelpRequest += new System.EventHandler(this.SelectMusicFolder_HelpRequest);
            // 
            // SongTimer
            // 
            this.SongTimer.Interval = 1000;
            this.SongTimer.Tick += new System.EventHandler(this.SongTimer_Tick);
            // 
            // MusicDirectoryButton
            // 
            this.MusicDirectoryButton.Location = new System.Drawing.Point(672, 12);
            this.MusicDirectoryButton.Name = "MusicDirectoryButton";
            this.MusicDirectoryButton.Size = new System.Drawing.Size(100, 65);
            this.MusicDirectoryButton.TabIndex = 6;
            this.MusicDirectoryButton.Text = "Add Directory for Music";
            this.MusicDirectoryButton.UseVisualStyleBackColor = true;
            this.MusicDirectoryButton.Click += new System.EventHandler(this.MusicDirectoryButton_Click);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(602, 126);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(182, 77);
            this.axWindowsMediaPlayer1.TabIndex = 4;
            this.axWindowsMediaPlayer1.TabStop = false;
            this.axWindowsMediaPlayer1.OpenStateChange += new AxWMPLib._WMPOCXEvents_OpenStateChangeEventHandler(this.axWindowsMediaPlayer1_OpenStateChange);
            this.axWindowsMediaPlayer1.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.axWindowsMediaPlayer1_MediaError);
            // 
            // MusicPlayer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.MusicDirectoryButton);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.SongTitleLabel);
            this.Controls.Add(this.MusicControllerPanel);
            this.Controls.Add(this.MusicPicture);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MusicPlayer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Player";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MusicPicture)).EndInit();
            this.MusicControllerPanel.ResumeLayout(false);
            this.MusicControllerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox MusicPicture;
        private System.Windows.Forms.Panel MusicControllerPanel;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PrevButton;
        private System.Windows.Forms.Label SongTitleLabel;
        private System.Windows.Forms.FolderBrowserDialog SelectMusicFolder;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Label TotalDurationLabel;
        private System.Windows.Forms.Timer SongTimer;
        private System.Windows.Forms.Label CurrentDurationLabel;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button MusicListButton;
        private System.Windows.Forms.Button MusicDirectoryButton;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}

