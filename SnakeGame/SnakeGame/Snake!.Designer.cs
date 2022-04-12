namespace SnakeGame
{
    partial class Snake_
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
            this.PicCanvas = new System.Windows.Forms.PictureBox();
            this.S1Score = new System.Windows.Forms.Label();
            this.S2Score = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.button1player = new System.Windows.Forms.Button();
            this.button2player = new System.Windows.Forms.Button();
            this.button3player = new System.Windows.Forms.Button();
            this.S3Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // PicCanvas
            // 
            this.PicCanvas.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.PicCanvas.Location = new System.Drawing.Point(3, 1);
            this.PicCanvas.Name = "PicCanvas";
            this.PicCanvas.Size = new System.Drawing.Size(579, 500);
            this.PicCanvas.TabIndex = 0;
            this.PicCanvas.TabStop = false;
            this.PicCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdateGrapichs);
            // 
            // S1Score
            // 
            this.S1Score.AutoSize = true;
            this.S1Score.BackColor = System.Drawing.Color.Black;
            this.S1Score.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S1Score.ForeColor = System.Drawing.Color.Green;
            this.S1Score.Location = new System.Drawing.Point(98, 504);
            this.S1Score.Name = "S1Score";
            this.S1Score.Size = new System.Drawing.Size(65, 21);
            this.S1Score.TabIndex = 1;
            this.S1Score.Text = "Score: 0";
            // 
            // S2Score
            // 
            this.S2Score.AutoSize = true;
            this.S2Score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.S2Score.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S2Score.ForeColor = System.Drawing.Color.Yellow;
            this.S2Score.Location = new System.Drawing.Point(270, 504);
            this.S2Score.Name = "S2Score";
            this.S2Score.Size = new System.Drawing.Size(65, 21);
            this.S2Score.TabIndex = 1;
            this.S2Score.Text = "Score: 0";
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 50;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // button1player
            // 
            this.button1player.BackColor = System.Drawing.Color.DarkGreen;
            this.button1player.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1player.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1player.Location = new System.Drawing.Point(69, 528);
            this.button1player.Name = "button1player";
            this.button1player.Size = new System.Drawing.Size(119, 29);
            this.button1player.TabIndex = 2;
            this.button1player.Text = "1 Player";
            this.button1player.UseVisualStyleBackColor = false;
            this.button1player.Click += new System.EventHandler(this.OnePlayer);
            // 
            // button2player
            // 
            this.button2player.BackColor = System.Drawing.Color.Yellow;
            this.button2player.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2player.Location = new System.Drawing.Point(241, 528);
            this.button2player.Name = "button2player";
            this.button2player.Size = new System.Drawing.Size(121, 29);
            this.button2player.TabIndex = 2;
            this.button2player.Text = "2 Player";
            this.button2player.UseVisualStyleBackColor = false;
            this.button2player.Click += new System.EventHandler(this.TwoPlayers);
            // 
            // button3player
            // 
            this.button3player.BackColor = System.Drawing.Color.DarkOrange;
            this.button3player.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3player.Location = new System.Drawing.Point(412, 528);
            this.button3player.Name = "button3player";
            this.button3player.Size = new System.Drawing.Size(117, 29);
            this.button3player.TabIndex = 2;
            this.button3player.Text = "3 Player";
            this.button3player.UseVisualStyleBackColor = false;
            this.button3player.Click += new System.EventHandler(this.ThreePlayers);
            // 
            // S3Score
            // 
            this.S3Score.AutoSize = true;
            this.S3Score.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.S3Score.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.S3Score.ForeColor = System.Drawing.Color.DarkOrange;
            this.S3Score.Location = new System.Drawing.Point(436, 504);
            this.S3Score.Name = "S3Score";
            this.S3Score.Size = new System.Drawing.Size(65, 21);
            this.S3Score.TabIndex = 1;
            this.S3Score.Text = "Score: 0";
            // 
            // Snake_
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.button3player);
            this.Controls.Add(this.button2player);
            this.Controls.Add(this.button1player);
            this.Controls.Add(this.S3Score);
            this.Controls.Add(this.S2Score);
            this.Controls.Add(this.S1Score);
            this.Controls.Add(this.PicCanvas);
            this.DoubleBuffered = true;
            this.Name = "Snake_";
            this.Text = "Snake!";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.PicCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicCanvas;
        private System.Windows.Forms.Label S1Score;
        private System.Windows.Forms.Label S2Score;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Button button1player;
        private System.Windows.Forms.Button button2player;
        private System.Windows.Forms.Button button3player;
        private System.Windows.Forms.Label S3Score;
    }
}