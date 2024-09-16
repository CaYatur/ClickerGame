namespace ClickerGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button2 = new Button();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            Puan = new Label();
            ClickerButton = new Button();
            InventoryButton = new Button();
            button3 = new Button();
            pictureBox1 = new PictureBox();
            leaderboardLabel = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox7 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 70);
            button1.Name = "button1";
            button1.Size = new Size(191, 23);
            button1.TabIndex = 0;
            button1.Text = "Giriş Yap";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += btnLogin_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 99);
            button2.Name = "button2";
            button2.Size = new Size(191, 23);
            button2.TabIndex = 1;
            button2.Text = "Kayıt Ol";
            button2.UseVisualStyleBackColor = true;
            button2.Visible = false;
            button2.Click += btnRegister_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(12, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(191, 23);
            txtUsername.TabIndex = 2;
            txtUsername.Visible = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(12, 41);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(191, 23);
            txtPassword.TabIndex = 3;
            txtPassword.Visible = false;
            // 
            // Puan
            // 
            Puan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Puan.AutoSize = true;
            Puan.Location = new Point(12, 200);
            Puan.Name = "Puan";
            Puan.Size = new Size(38, 15);
            Puan.TabIndex = 4;
            Puan.Text = "label1";
            // 
            // ClickerButton
            // 
            ClickerButton.Location = new Point(460, 125);
            ClickerButton.Name = "ClickerButton";
            ClickerButton.Size = new Size(212, 82);
            ClickerButton.TabIndex = 5;
            ClickerButton.Text = "button3";
            ClickerButton.UseVisualStyleBackColor = true;
            ClickerButton.Visible = false;
            ClickerButton.Click += ClickerButton_Click;
            // 
            // InventoryButton
            // 
            InventoryButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            InventoryButton.Location = new Point(403, 374);
            InventoryButton.Name = "InventoryButton";
            InventoryButton.Size = new Size(164, 44);
            InventoryButton.TabIndex = 6;
            InventoryButton.Text = "Envanter";
            InventoryButton.UseVisualStyleBackColor = true;
            InventoryButton.Visible = false;
            InventoryButton.Click += InventoryButton_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(403, 324);
            button3.Name = "button3";
            button3.Size = new Size(164, 44);
            button3.TabIndex = 7;
            button3.Text = "Pazar";
            button3.UseVisualStyleBackColor = true;
            button3.Visible = false;
            button3.Click += btnOpenMarket_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox1.Image = Properties.Resources.KV1;
            pictureBox1.Location = new Point(12, 218);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            pictureBox1.Click += ClickerButton_Click;
            // 
            // leaderboardLabel
            // 
            leaderboardLabel.AutoSize = true;
            leaderboardLabel.Location = new Point(12, 9);
            leaderboardLabel.Name = "leaderboardLabel";
            leaderboardLabel.RightToLeft = RightToLeft.No;
            leaderboardLabel.Size = new Size(52, 15);
            leaderboardLabel.TabIndex = 9;
            leaderboardLabel.Text = "Sıralama";
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.Envanter75;
            pictureBox2.Location = new Point(492, 342);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(75, 75);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Click += InventoryButton_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox3.Image = Properties.Resources.Pazar75;
            pictureBox3.Location = new Point(492, 261);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(75, 75);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 11;
            pictureBox3.TabStop = false;
            pictureBox3.Click += btnOpenMarket_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox4.Image = Properties.Resources.Luck;
            pictureBox4.Location = new Point(492, 180);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(75, 75);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 12;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox5.Image = Properties.Resources.Game;
            pictureBox5.Location = new Point(492, 99);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(75, 75);
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.TabIndex = 13;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox6.Image = Properties.Resources.Game;
            pictureBox6.Location = new Point(403, 389);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(75, 75);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            pictureBox6.Visible = false;
            pictureBox6.Click += pictureBox6_Click;
            // 
            // pictureBox7
            // 
            pictureBox7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pictureBox7.Image = Properties.Resources.GameMemory;
            pictureBox7.Location = new Point(492, 18);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(75, 75);
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.TabIndex = 16;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 430);
            Controls.Add(pictureBox7);
            Controls.Add(pictureBox6);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(leaderboardLabel);
            Controls.Add(button3);
            Controls.Add(InventoryButton);
            Controls.Add(ClickerButton);
            Controls.Add(Puan);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tıklama Oyunu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Label Puan;
        private Button ClickerButton;
        private Button InventoryButton;
        private Button button3;
        private PictureBox pictureBox1;
        private Label leaderboardLabel;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
    }
}
