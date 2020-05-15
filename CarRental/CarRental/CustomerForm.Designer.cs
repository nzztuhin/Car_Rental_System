namespace CarRental
{
    partial class CustomerForm
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
            this.rentACarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crpanel = new System.Windows.Forms.Panel();
            this.lbl1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.crpanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.BlueViolet;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rentACarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // rentACarToolStripMenuItem
            // 
            this.rentACarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rentACarToolStripMenuItem.Name = "rentACarToolStripMenuItem";
            this.rentACarToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.rentACarToolStripMenuItem.Text = "Rent ";
            this.rentACarToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rentACarToolStripMenuItem.Click += new System.EventHandler(this.rentACarToolStripMenuItem_Click);
            // 
            // crpanel
            // 
            this.crpanel.Controls.Add(this.lbl1);
            this.crpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crpanel.ForeColor = System.Drawing.Color.Black;
            this.crpanel.Location = new System.Drawing.Point(0, 24);
            this.crpanel.Name = "crpanel";
            this.crpanel.Size = new System.Drawing.Size(996, 649);
            this.crpanel.TabIndex = 4;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(357, 37);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(66, 24);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "empty";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 673);
            this.Controls.Add(this.crpanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomerForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.crpanel.ResumeLayout(false);
            this.crpanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rentACarToolStripMenuItem;
        private System.Windows.Forms.Panel crpanel;
        private System.Windows.Forms.Label lbl1;
    }
}