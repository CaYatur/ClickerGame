namespace ClickerGame
{
    partial class DailyRewards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailyRewards));
            lblDayInfo = new Label();
            lblRewardInfo = new Label();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblDayInfo
            // 
            lblDayInfo.AutoSize = true;
            lblDayInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDayInfo.Location = new Point(12, 9);
            lblDayInfo.Name = "lblDayInfo";
            lblDayInfo.Size = new Size(91, 21);
            lblDayInfo.TabIndex = 0;
            lblDayInfo.Text = "lblDayInfo";
            // 
            // lblRewardInfo
            // 
            lblRewardInfo.AutoSize = true;
            lblRewardInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRewardInfo.Location = new Point(12, 30);
            lblRewardInfo.Name = "lblRewardInfo";
            lblRewardInfo.Size = new Size(118, 21);
            lblRewardInfo.TabIndex = 1;
            lblRewardInfo.Text = "lblRewardInfo";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            richTextBox1.Location = new Point(12, 68);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(444, 259);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(360, 333);
            button1.Name = "button1";
            button1.Size = new Size(96, 36);
            button1.TabIndex = 4;
            button1.Text = "Kapat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DailyRewards
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(468, 381);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(lblRewardInfo);
            Controls.Add(lblDayInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DailyRewards";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Günlük Ödül";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDayInfo;
        private Label lblRewardInfo;
        private RichTextBox richTextBox1;
        private Button button1;
    }
}