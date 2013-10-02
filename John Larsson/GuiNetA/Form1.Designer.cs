namespace GuiNetA
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.läsInHeltal = new System.Windows.Forms.ToolStripMenuItem();
            this.skrivToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skrivHeltalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avslutaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avslutaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.skrivToolStripMenuItem,
            this.avslutaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.läsInHeltal});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem.Text = "&Läs";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // läsInHeltal
            // 
            this.läsInHeltal.Name = "läsInHeltal";
            this.läsInHeltal.Size = new System.Drawing.Size(136, 22);
            this.läsInHeltal.Text = "Läs in heltal";
            this.läsInHeltal.Click += new System.EventHandler(this.läsInHeltal_Click);
            // 
            // skrivToolStripMenuItem
            // 
            this.skrivToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skrivHeltalToolStripMenuItem});
            this.skrivToolStripMenuItem.Name = "skrivToolStripMenuItem";
            this.skrivToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.skrivToolStripMenuItem.Text = "&Skriv";
            // 
            // skrivHeltalToolStripMenuItem
            // 
            this.skrivHeltalToolStripMenuItem.Name = "skrivHeltalToolStripMenuItem";
            this.skrivHeltalToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.skrivHeltalToolStripMenuItem.Text = "Skriv heltal";
            this.skrivHeltalToolStripMenuItem.Click += new System.EventHandler(this.skrivHeltalToolStripMenuItem_Click);
            // 
            // avslutaToolStripMenuItem
            // 
            this.avslutaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avslutaToolStripMenuItem1});
            this.avslutaToolStripMenuItem.Name = "avslutaToolStripMenuItem";
            this.avslutaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.avslutaToolStripMenuItem.Text = "&Avsluta";
            // 
            // avslutaToolStripMenuItem1
            // 
            this.avslutaToolStripMenuItem1.Name = "avslutaToolStripMenuItem1";
            this.avslutaToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.avslutaToolStripMenuItem1.Text = "Avsluta";
            this.avslutaToolStripMenuItem1.Click += new System.EventHandler(this.avslutaToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Heltal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem läsInHeltal;
        private System.Windows.Forms.ToolStripMenuItem skrivToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skrivHeltalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avslutaToolStripMenuItem1;
    }
}

