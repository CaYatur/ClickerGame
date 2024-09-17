namespace ClickerGame
{
    partial class MemoryGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryGame));
            pictureBoxMain = new PictureBox();
            pictureBoxGuess1 = new PictureBox();
            pictureBoxGuess2 = new PictureBox();
            pictureBoxGuess3 = new PictureBox();
            pictureBoxGuess4 = new PictureBox();
            pictureBoxGuess5 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess5).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Location = new Point(170, 12);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(200, 200);
            pictureBoxMain.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMain.TabIndex = 0;
            pictureBoxMain.TabStop = false;
            // 
            // pictureBoxGuess1
            // 
            pictureBoxGuess1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxGuess1.Location = new Point(12, 218);
            pictureBoxGuess1.Name = "pictureBoxGuess1";
            pictureBoxGuess1.Size = new Size(100, 100);
            pictureBoxGuess1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGuess1.TabIndex = 1;
            pictureBoxGuess1.TabStop = false;
            // 
            // pictureBoxGuess2
            // 
            pictureBoxGuess2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxGuess2.Location = new Point(118, 218);
            pictureBoxGuess2.Name = "pictureBoxGuess2";
            pictureBoxGuess2.Size = new Size(100, 100);
            pictureBoxGuess2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGuess2.TabIndex = 2;
            pictureBoxGuess2.TabStop = false;
            // 
            // pictureBoxGuess3
            // 
            pictureBoxGuess3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxGuess3.Location = new Point(224, 218);
            pictureBoxGuess3.Name = "pictureBoxGuess3";
            pictureBoxGuess3.Size = new Size(100, 100);
            pictureBoxGuess3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGuess3.TabIndex = 3;
            pictureBoxGuess3.TabStop = false;
            // 
            // pictureBoxGuess4
            // 
            pictureBoxGuess4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxGuess4.Location = new Point(330, 218);
            pictureBoxGuess4.Name = "pictureBoxGuess4";
            pictureBoxGuess4.Size = new Size(100, 100);
            pictureBoxGuess4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGuess4.TabIndex = 4;
            pictureBoxGuess4.TabStop = false;
            // 
            // pictureBoxGuess5
            // 
            pictureBoxGuess5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBoxGuess5.Location = new Point(436, 218);
            pictureBoxGuess5.Name = "pictureBoxGuess5";
            pictureBoxGuess5.Size = new Size(100, 100);
            pictureBoxGuess5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxGuess5.TabIndex = 5;
            pictureBoxGuess5.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(143, 17);
            label1.TabIndex = 6;
            label1.Text = "Sıralamayı aklında tut";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(12, 167);
            label2.Name = "label2";
            label2.Size = new Size(210, 45);
            label2.TabIndex = 7;
            label2.Text = "KAZANDIN!";
            label2.Visible = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(436, 12);
            button1.Name = "button1";
            button1.Size = new Size(106, 38);
            button1.TabIndex = 8;
            button1.Text = "Lobiye Dön";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // MemoryGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 343);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxGuess5);
            Controls.Add(pictureBoxGuess4);
            Controls.Add(pictureBoxGuess3);
            Controls.Add(pictureBoxGuess2);
            Controls.Add(pictureBoxGuess1);
            Controls.Add(pictureBoxMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MemoryGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hafıza Oyunu";
            FormClosing += MemoryGame_FormClosing;
            Load += MemoryGame_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGuess5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxMain;
        private PictureBox pictureBoxGuess1;
        private PictureBox pictureBoxGuess2;
        private PictureBox pictureBoxGuess3;
        private PictureBox pictureBoxGuess4;
        private PictureBox pictureBoxGuess5;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}