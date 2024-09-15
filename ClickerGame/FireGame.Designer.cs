namespace ClickerGame
{
    partial class FireGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FireGame));
            pictureBox1 = new PictureBox();
            labelScore = new Label();
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.KV1;
            pictureBox1.Location = new Point(12, 165);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // labelScore
            // 
            labelScore.AutoSize = true;
            labelScore.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelScore.Location = new Point(12, 9);
            labelScore.Name = "labelScore";
            labelScore.Size = new Size(71, 17);
            labelScore.TabIndex = 1;
            labelScore.Text = "labelScore";
            labelScore.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(270, 188);
            button1.Name = "button1";
            button1.Size = new Size(223, 100);
            button1.TabIndex = 2;
            button1.Text = "Oyunu Başlat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(270, 291);
            label2.Name = "label2";
            label2.Size = new Size(648, 30);
            label2.TabIndex = 3;
            label2.Text = "Her ateş için 20 Puan eksilir. Her isabetli atışta ise 25 puan verilir.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 72F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(87, 313);
            label1.Name = "label1";
            label1.Size = new Size(590, 128);
            label1.TabIndex = 4;
            label1.Text = "OYUN BİTTİ";
            label1.Visible = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = SystemColors.MenuHighlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.ForeColor = Color.White;
            button2.Location = new Point(565, 338);
            button2.Name = "button2";
            button2.Size = new Size(223, 100);
            button2.TabIndex = 5;
            button2.Text = "Lobiye Dön";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // FireGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(labelScore);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FireGame";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FireGame";
            WindowState = FormWindowState.Maximized;
            Load += FireGame_Load;
            MouseDown += GameForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelScore;
        private Button button1;
        private Label label2;
        private Label label1;
        private Button button2;
    }
}