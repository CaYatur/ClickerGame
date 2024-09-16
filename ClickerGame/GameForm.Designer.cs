namespace ClickerGame
{
    partial class GameForm
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
            labelHostPlayer = new Label();
            labelJoinedPlayer = new Label();
            labelHostScore = new Label();
            labelJoinedScore = new Label();
            buttonHost = new Button();
            buttonJoined = new Button();
            labelTimeRemaining = new Label();
            SuspendLayout();
            // 
            // labelHostPlayer
            // 
            labelHostPlayer.AutoSize = true;
            labelHostPlayer.Location = new Point(12, 210);
            labelHostPlayer.Name = "labelHostPlayer";
            labelHostPlayer.Size = new Size(89, 15);
            labelHostPlayer.TabIndex = 0;
            labelHostPlayer.Text = "labelHostPlayer";
            // 
            // labelJoinedPlayer
            // 
            labelJoinedPlayer.AutoSize = true;
            labelJoinedPlayer.Location = new Point(482, 210);
            labelJoinedPlayer.Name = "labelJoinedPlayer";
            labelJoinedPlayer.Size = new Size(98, 15);
            labelJoinedPlayer.TabIndex = 1;
            labelJoinedPlayer.Text = "labelJoinedPlayer";
            // 
            // labelHostScore
            // 
            labelHostScore.AutoSize = true;
            labelHostScore.Location = new Point(134, 210);
            labelHostScore.Name = "labelHostScore";
            labelHostScore.Size = new Size(86, 15);
            labelHostScore.TabIndex = 2;
            labelHostScore.Text = "labelHostScore";
            // 
            // labelJoinedScore
            // 
            labelJoinedScore.AutoSize = true;
            labelJoinedScore.Location = new Point(604, 210);
            labelJoinedScore.Name = "labelJoinedScore";
            labelJoinedScore.Size = new Size(95, 15);
            labelJoinedScore.TabIndex = 3;
            labelJoinedScore.Text = "labelJoinedScore";
            // 
            // buttonHost
            // 
            buttonHost.Location = new Point(73, 276);
            buttonHost.Name = "buttonHost";
            buttonHost.Size = new Size(121, 67);
            buttonHost.TabIndex = 4;
            buttonHost.Text = "buttonHost";
            buttonHost.UseVisualStyleBackColor = true;
            buttonHost.Click += buttonHost_Click;
            // 
            // buttonJoined
            // 
            buttonJoined.Location = new Point(526, 276);
            buttonJoined.Name = "buttonJoined";
            buttonJoined.Size = new Size(121, 67);
            buttonJoined.TabIndex = 5;
            buttonJoined.Text = "buttonJoined";
            buttonJoined.UseVisualStyleBackColor = true;
            buttonJoined.Click += buttonJoined_Click;
            // 
            // labelTimeRemaining
            // 
            labelTimeRemaining.AutoSize = true;
            labelTimeRemaining.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelTimeRemaining.Location = new Point(12, 9);
            labelTimeRemaining.Name = "labelTimeRemaining";
            labelTimeRemaining.Size = new Size(169, 21);
            labelTimeRemaining.TabIndex = 6;
            labelTimeRemaining.Text = "labelTimeRemaining";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelTimeRemaining);
            Controls.Add(buttonJoined);
            Controls.Add(buttonHost);
            Controls.Add(labelJoinedScore);
            Controls.Add(labelHostScore);
            Controls.Add(labelJoinedPlayer);
            Controls.Add(labelHostPlayer);
            Name = "GameForm";
            Text = "GameForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHostPlayer;
        private Label labelJoinedPlayer;
        private Label labelHostScore;
        private Label labelJoinedScore;
        private Button buttonHost;
        private Button buttonJoined;
        private Label labelTimeRemaining;
    }
}