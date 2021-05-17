using System.Windows.Forms;

namespace SpaceImpact
{
    partial class SpaceImpact
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
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.Surface = new System.Windows.Forms.PictureBox();
            this.Heart1 = new System.Windows.Forms.PictureBox();
            this.Heart2 = new System.Windows.Forms.PictureBox();
            this.Heart3 = new System.Windows.Forms.PictureBox();
            this.Surface2 = new System.Windows.Forms.PictureBox();
            this.ShipMovementTimer = new System.Windows.Forms.Timer(this.components);
            this.LevelTrainsitionTimer = new System.Windows.Forms.Timer(this.components);
            this.ShootingTimer = new System.Windows.Forms.Timer(this.components);
            this.InfoLabel = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.GameOverLabel = new System.Windows.Forms.Label();
            this.PausedLabel = new System.Windows.Forms.Label();
            this.HighScoreLabel = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.Heart4 = new System.Windows.Forms.PictureBox();
            this.Heart5 = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.Highscore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Surface)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Surface2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart5)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 10;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // Surface
            // 
            this.Surface.BackColor = System.Drawing.Color.Olive;
            this.Surface.Location = new System.Drawing.Point(0, 470);
            this.Surface.Name = "Surface";
            this.Surface.Size = new System.Drawing.Size(800, 100);
            this.Surface.TabIndex = 0;
            this.Surface.TabStop = false;
            // 
            // Heart1
            // 
            this.Heart1.BackColor = System.Drawing.Color.Olive;
            this.Heart1.Location = new System.Drawing.Point(10, 10);
            this.Heart1.Name = "Heart1";
            this.Heart1.Size = new System.Drawing.Size(40, 40);
            this.Heart1.TabIndex = 2;
            this.Heart1.TabStop = false;
            // 
            // Heart2
            // 
            this.Heart2.BackColor = System.Drawing.Color.Olive;
            this.Heart2.Location = new System.Drawing.Point(55, 10);
            this.Heart2.Name = "Heart2";
            this.Heart2.Size = new System.Drawing.Size(40, 40);
            this.Heart2.TabIndex = 3;
            this.Heart2.TabStop = false;
            // 
            // Heart3
            // 
            this.Heart3.BackColor = System.Drawing.Color.Olive;
            this.Heart3.Location = new System.Drawing.Point(100, 10);
            this.Heart3.Name = "Heart3";
            this.Heart3.Size = new System.Drawing.Size(40, 40);
            this.Heart3.TabIndex = 4;
            this.Heart3.TabStop = false;
            // 
            // Surface2
            // 
            this.Surface2.BackColor = System.Drawing.Color.DimGray;
            this.Surface2.Location = new System.Drawing.Point(800, 470);
            this.Surface2.Name = "Surface2";
            this.Surface2.Size = new System.Drawing.Size(800, 100);
            this.Surface2.TabIndex = 15;
            this.Surface2.TabStop = false;
            // 
            // ShipMovementTimer
            // 
            this.ShipMovementTimer.Enabled = true;
            this.ShipMovementTimer.Interval = 10;
            this.ShipMovementTimer.Tick += new System.EventHandler(this.ShipMovementTimer_Tick);
            // 
            // LevelTrainsitionTimer
            // 
            this.LevelTrainsitionTimer.Interval = 10;
            this.LevelTrainsitionTimer.Tick += new System.EventHandler(this.LevelTransitionTimer_Tick);
            // 
            // ShootingTimer
            // 
            this.ShootingTimer.Interval = 10;
            this.ShootingTimer.Tick += new System.EventHandler(this.ShootingTimer_Tick);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Font = new System.Drawing.Font("MS Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoLabel.Location = new System.Drawing.Point(240, 180);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(320, 20);
            this.InfoLabel.TabIndex = 16;
            this.InfoLabel.Text = "X->shoot   Arrows->move   Click->pause";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.Font = new System.Drawing.Font("MS Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(670, 25);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ScoreLabel.Size = new System.Drawing.Size(120, 25);
            this.ScoreLabel.TabIndex = 17;
            this.ScoreLabel.Text = "000000";
            // 
            // GameOverLabel
            // 
            this.GameOverLabel.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverLabel.Location = new System.Drawing.Point(150, 200);
            this.GameOverLabel.Name = "GameOverLabel";
            this.GameOverLabel.Size = new System.Drawing.Size(500, 100);
            this.GameOverLabel.TabIndex = 18;
            this.GameOverLabel.Text = "GAME OVER";
            this.GameOverLabel.Visible = false;
            // 
            // PausedLabel
            // 
            this.PausedLabel.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PausedLabel.Location = new System.Drawing.Point(230, 200);
            this.PausedLabel.Name = "PausedLabel";
            this.PausedLabel.Size = new System.Drawing.Size(340, 100);
            this.PausedLabel.TabIndex = 19;
            this.PausedLabel.Text = "PAUSED";
            this.PausedLabel.Visible = false;
            this.PausedLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PauseUnpause);
            // 
            // HighScoreLabel
            // 
            this.HighScoreLabel.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighScoreLabel.Location = new System.Drawing.Point(730, 10);
            this.HighScoreLabel.Name = "HighScoreLabel";
            this.HighScoreLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.HighScoreLabel.Size = new System.Drawing.Size(50, 12);
            this.HighScoreLabel.TabIndex = 20;
            this.HighScoreLabel.Text = "000000";
            // 
            // RestartButton
            // 
            this.RestartButton.BackColor = System.Drawing.Color.Olive;
            this.RestartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RestartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RestartButton.Font = new System.Drawing.Font("MS Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestartButton.Location = new System.Drawing.Point(310, 310);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RestartButton.Size = new System.Drawing.Size(180, 50);
            this.RestartButton.TabIndex = 21;
            this.RestartButton.Text = "RETRY";
            this.RestartButton.UseVisualStyleBackColor = false;
            this.RestartButton.Visible = false;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // Heart4
            // 
            this.Heart4.BackColor = System.Drawing.Color.Olive;
            this.Heart4.Location = new System.Drawing.Point(145, 10);
            this.Heart4.Name = "Heart4";
            this.Heart4.Size = new System.Drawing.Size(40, 40);
            this.Heart4.TabIndex = 4;
            this.Heart4.TabStop = false;
            this.Heart4.Visible = false;
            // 
            // Heart5
            // 
            this.Heart5.BackColor = System.Drawing.Color.Olive;
            this.Heart5.Location = new System.Drawing.Point(190, 10);
            this.Heart5.Name = "Heart5";
            this.Heart5.Size = new System.Drawing.Size(40, 40);
            this.Heart5.TabIndex = 4;
            this.Heart5.TabStop = false;
            this.Heart5.Visible = false;
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Olive;
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Font = new System.Drawing.Font("MS Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(310, 220);
            this.StartButton.Name = "StartButton";
            this.StartButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartButton.Size = new System.Drawing.Size(180, 50);
            this.StartButton.TabIndex = 21;
            this.StartButton.Text = "GOT IT";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Highscore
            // 
            this.Highscore.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Highscore.Location = new System.Drawing.Point(670, 10);
            this.Highscore.Name = "Highscore";
            this.Highscore.Size = new System.Drawing.Size(70, 12);
            this.Highscore.TabIndex = 20;
            this.Highscore.Text = "Highscore:";
            // 
            // SpaceImpact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.Olive;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.Highscore);
            this.Controls.Add(this.HighScoreLabel);
            this.Controls.Add(this.PausedLabel);
            this.Controls.Add(this.GameOverLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.Surface2);
            this.Controls.Add(this.Heart5);
            this.Controls.Add(this.Heart4);
            this.Controls.Add(this.Heart3);
            this.Controls.Add(this.Heart2);
            this.Controls.Add(this.Heart1);
            this.Controls.Add(this.Surface);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "SpaceImpact";
            this.Text = "Space Impact";
            this.Load += new System.EventHandler(this.SpaceImpact_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SpaceImpact_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SpaceImpact_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PauseUnpause);
            ((System.ComponentModel.ISupportInitialize)(this.Surface)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Surface2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Heart5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.PictureBox Surface;
        private System.Windows.Forms.PictureBox Heart1;
        private System.Windows.Forms.PictureBox Heart2;
        private System.Windows.Forms.PictureBox Heart3;
        private System.Windows.Forms.PictureBox Surface2;
        private System.Windows.Forms.Timer ShipMovementTimer;
        private Timer LevelTrainsitionTimer;
        private Timer ShootingTimer;
        private Label InfoLabel;
        private Label ScoreLabel;
        private Label GameOverLabel;
        private Label PausedLabel;
        private Label HighScoreLabel;
        private Button RestartButton;
        private PictureBox Heart4;
        private PictureBox Heart5;
        private Button StartButton;
        private Label Highscore;
    }
}