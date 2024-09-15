namespace ClickerGame
{
    partial class FindCorrect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindCorrect));
            btnOption1 = new Button();
            btnOption2 = new Button();
            btnOption3 = new Button();
            pictureBox1 = new PictureBox();
            lblRiskAmount = new Label();
            lblCurrentScore = new Label();
            label1 = new Label();
            btnOption4 = new Button();
            btnOption5 = new Button();
            btnOption6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnOption1
            // 
            btnOption1.BackColor = SystemColors.MenuHighlight;
            btnOption1.FlatStyle = FlatStyle.Flat;
            btnOption1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption1.ForeColor = SystemColors.ButtonFace;
            btnOption1.Location = new Point(12, 46);
            btnOption1.Name = "btnOption1";
            btnOption1.Size = new Size(113, 75);
            btnOption1.TabIndex = 0;
            btnOption1.Text = "1";
            btnOption1.UseVisualStyleBackColor = false;
            btnOption1.Click += Button_Click;
            // 
            // btnOption2
            // 
            btnOption2.BackColor = SystemColors.MenuHighlight;
            btnOption2.FlatStyle = FlatStyle.Flat;
            btnOption2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption2.ForeColor = SystemColors.ButtonFace;
            btnOption2.Location = new Point(131, 46);
            btnOption2.Name = "btnOption2";
            btnOption2.Size = new Size(113, 75);
            btnOption2.TabIndex = 1;
            btnOption2.Text = "2";
            btnOption2.UseVisualStyleBackColor = false;
            btnOption2.Click += Button_Click;
            // 
            // btnOption3
            // 
            btnOption3.BackColor = SystemColors.MenuHighlight;
            btnOption3.FlatStyle = FlatStyle.Flat;
            btnOption3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption3.ForeColor = SystemColors.ButtonFace;
            btnOption3.Location = new Point(250, 46);
            btnOption3.Name = "btnOption3";
            btnOption3.Size = new Size(113, 75);
            btnOption3.TabIndex = 2;
            btnOption3.Text = "3";
            btnOption3.UseVisualStyleBackColor = false;
            btnOption3.Click += Button_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Location = new Point(12, 237);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // lblRiskAmount
            // 
            lblRiskAmount.AutoSize = true;
            lblRiskAmount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblRiskAmount.ForeColor = SystemColors.Control;
            lblRiskAmount.Location = new Point(12, 9);
            lblRiskAmount.Name = "lblRiskAmount";
            lblRiskAmount.Size = new Size(41, 17);
            lblRiskAmount.TabIndex = 5;
            lblRiskAmount.Text = "label1";
            // 
            // lblCurrentScore
            // 
            lblCurrentScore.AutoSize = true;
            lblCurrentScore.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            lblCurrentScore.ForeColor = SystemColors.Control;
            lblCurrentScore.Location = new Point(12, 26);
            lblCurrentScore.Name = "lblCurrentScore";
            lblCurrentScore.Size = new Size(43, 17);
            lblCurrentScore.TabIndex = 6;
            lblCurrentScore.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(12, 217);
            label1.Name = "label1";
            label1.Size = new Size(182, 17);
            label1.TabIndex = 8;
            label1.Text = "Doğru Düğmeyi Tahmin Edin";
            // 
            // btnOption4
            // 
            btnOption4.BackColor = SystemColors.MenuHighlight;
            btnOption4.FlatStyle = FlatStyle.Flat;
            btnOption4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption4.ForeColor = SystemColors.ButtonFace;
            btnOption4.Location = new Point(12, 127);
            btnOption4.Name = "btnOption4";
            btnOption4.Size = new Size(113, 75);
            btnOption4.TabIndex = 9;
            btnOption4.Text = "4";
            btnOption4.UseVisualStyleBackColor = false;
            btnOption4.Click += Button_Click;
            // 
            // btnOption5
            // 
            btnOption5.BackColor = SystemColors.MenuHighlight;
            btnOption5.FlatStyle = FlatStyle.Flat;
            btnOption5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption5.ForeColor = SystemColors.ButtonFace;
            btnOption5.Location = new Point(131, 127);
            btnOption5.Name = "btnOption5";
            btnOption5.Size = new Size(113, 75);
            btnOption5.TabIndex = 10;
            btnOption5.Text = "5";
            btnOption5.UseVisualStyleBackColor = false;
            btnOption5.Click += Button_Click;
            // 
            // btnOption6
            // 
            btnOption6.BackColor = SystemColors.MenuHighlight;
            btnOption6.FlatStyle = FlatStyle.Flat;
            btnOption6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOption6.ForeColor = SystemColors.ButtonFace;
            btnOption6.Location = new Point(250, 127);
            btnOption6.Name = "btnOption6";
            btnOption6.Size = new Size(113, 75);
            btnOption6.TabIndex = 11;
            btnOption6.Text = "6";
            btnOption6.UseVisualStyleBackColor = false;
            btnOption6.Click += Button_Click;
            // 
            // FindCorrect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Teal;
            ClientSize = new Size(379, 449);
            Controls.Add(btnOption6);
            Controls.Add(btnOption5);
            Controls.Add(btnOption4);
            Controls.Add(label1);
            Controls.Add(lblCurrentScore);
            Controls.Add(lblRiskAmount);
            Controls.Add(pictureBox1);
            Controls.Add(btnOption3);
            Controls.Add(btnOption2);
            Controls.Add(btnOption1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FindCorrect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doğru Düğmeyi Bul";
            FormClosing += FindCorrect_FormClosing;
            Load += FindCorrect_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOption1;
        private Button btnOption2;
        private Button btnOption3;
        private PictureBox pictureBox1;
        private Label lblRiskAmount;
        private Label lblCurrentScore;
        private Label label1;
        private Button btnOption4;
        private Button btnOption5;
        private Button btnOption6;
    }
}