namespace ClickerGame
{
    partial class MarketForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarketForm));
            button1 = new Button();
            button2 = new Button();
            marketListBox = new ListBox();
            inventoryListBox = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(361, 217);
            button1.Name = "button1";
            button1.Size = new Size(270, 23);
            button1.TabIndex = 1;
            button1.Text = "Seçili Öğeyi Pazara Koy";
            button1.UseVisualStyleBackColor = true;
            button1.Click += sellButton_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Location = new Point(12, 217);
            button2.Name = "button2";
            button2.Size = new Size(337, 23);
            button2.TabIndex = 2;
            button2.Text = "Pazardan Geri Çek";
            button2.UseVisualStyleBackColor = true;
            button2.Click += removeButton_Click;
            // 
            // marketListBox
            // 
            marketListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            marketListBox.FormattingEnabled = true;
            marketListBox.ItemHeight = 15;
            marketListBox.Location = new Point(12, 12);
            marketListBox.Name = "marketListBox";
            marketListBox.Size = new Size(337, 199);
            marketListBox.TabIndex = 3;
            marketListBox.DoubleClick += marketListBox_DoubleClick;
            // 
            // inventoryListBox
            // 
            inventoryListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            inventoryListBox.FormattingEnabled = true;
            inventoryListBox.ItemHeight = 15;
            inventoryListBox.Location = new Point(361, 12);
            inventoryListBox.Name = "inventoryListBox";
            inventoryListBox.Size = new Size(270, 199);
            inventoryListBox.TabIndex = 4;
            // 
            // MarketForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(643, 250);
            Controls.Add(inventoryListBox);
            Controls.Add(marketListBox);
            Controls.Add(button2);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MarketForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Topluluk Pazarı";
            Load += MarketForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private ListBox marketListBox;
        private ListBox inventoryListBox;
    }
}