namespace userConfApp
{
    partial class About
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
            this.versionLabel = new System.Windows.Forms.Label();
            this.versionContLabel = new System.Windows.Forms.Label();
            this.uptimeLabel = new System.Windows.Forms.Label();
            this.uptimeCont = new System.Windows.Forms.Label();
            this.topLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(10, 57);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(48, 15);
            this.versionLabel.TabIndex = 0;
            this.versionLabel.Text = "Version:";
            // 
            // versionContLabel
            // 
            this.versionContLabel.AutoSize = true;
            this.versionContLabel.Location = new System.Drawing.Point(64, 57);
            this.versionContLabel.Name = "versionContLabel";
            this.versionContLabel.Size = new System.Drawing.Size(64, 15);
            this.versionContLabel.TabIndex = 1;
            this.versionContLabel.Text = "notLoaded";
            // 
            // uptimeLabel
            // 
            this.uptimeLabel.AutoSize = true;
            this.uptimeLabel.Location = new System.Drawing.Point(10, 72);
            this.uptimeLabel.Name = "uptimeLabel";
            this.uptimeLabel.Size = new System.Drawing.Size(49, 15);
            this.uptimeLabel.TabIndex = 2;
            this.uptimeLabel.Text = "Uptime:";
            this.uptimeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // uptimeCont
            // 
            this.uptimeCont.AutoSize = true;
            this.uptimeCont.Location = new System.Drawing.Point(64, 72);
            this.uptimeCont.Name = "uptimeCont";
            this.uptimeCont.Size = new System.Drawing.Size(64, 15);
            this.uptimeCont.TabIndex = 3;
            this.uptimeCont.Text = "notLoaded";
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Location = new System.Drawing.Point(10, 9);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(76, 15);
            this.topLabel.TabIndex = 4;
            this.topLabel.Text = "Test Program";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 161);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.uptimeCont);
            this.Controls.Add(this.uptimeLabel);
            this.Controls.Add(this.versionContLabel);
            this.Controls.Add(this.versionLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label versionLabel;
        private Label versionContLabel;
        private Label uptimeLabel;
        private Label uptimeCont;
        private Label topLabel;
    }
}