namespace ClickerGame
{
    partial class FindCorrectPoints
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindCorrectPoints));
            lblCurrentScore = new Label();
            txtRiskAmount = new TextBox();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblCurrentScore
            // 
            lblCurrentScore.AutoSize = true;
            lblCurrentScore.Location = new Point(12, 9);
            lblCurrentScore.Name = "lblCurrentScore";
            lblCurrentScore.Size = new Size(47, 15);
            lblCurrentScore.TabIndex = 0;
            lblCurrentScore.Text = "Mevcut";
            // 
            // txtRiskAmount
            // 
            txtRiskAmount.Location = new Point(12, 42);
            txtRiskAmount.Name = "txtRiskAmount";
            txtRiskAmount.Size = new Size(196, 23);
            txtRiskAmount.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(196, 15);
            label1.TabIndex = 2;
            label1.Text = "Riske Atmak İstediğiniz Miktarı Girin";
            // 
            // button1
            // 
            button1.Location = new Point(12, 71);
            button1.Name = "button1";
            button1.Size = new Size(196, 23);
            button1.TabIndex = 3;
            button1.Text = "Riske At";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnSubmit_Click;
            // 
            // FindCorrectPoints
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228, 106);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(txtRiskAmount);
            Controls.Add(lblCurrentScore);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FindCorrectPoints";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Puanı Riske Atma";
            Load += FindCorrectPoints_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentScore;
        private TextBox txtRiskAmount;
        private Label label1;
        private Button button1;
    }
}