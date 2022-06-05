namespace userConfApp
{
    partial class mainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGrid = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Encoded = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.saveButton = new System.Windows.Forms.Button();
            this.generatePassLabel = new System.Windows.Forms.Label();
            this.groupBoxPassGen = new System.Windows.Forms.GroupBox();
            this.generatePassBnt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).BeginInit();
            this.groupBoxPassGen.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(584, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // userGrid
            // 
            this.userGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Enabled,
            this.Username,
            this.Password,
            this.Encoded});
            this.userGrid.Location = new System.Drawing.Point(12, 27);
            this.userGrid.Name = "userGrid";
            this.userGrid.RowTemplate.Height = 25;
            this.userGrid.Size = new System.Drawing.Size(560, 300);
            this.userGrid.TabIndex = 7;
            this.userGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.userGrid_CellValueChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Enabled
            // 
            this.Enabled.HeaderText = "Enabled";
            this.Enabled.Name = "Enabled";
            this.Enabled.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Enabled.Width = 60;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // Password
            // 
            this.Password.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // Encoded
            // 
            this.Encoded.HeaderText = "Encoded";
            this.Encoded.Name = "Encoded";
            this.Encoded.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Encoded.Width = 60;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(497, 333);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // generatePassLabel
            // 
            this.generatePassLabel.AutoSize = true;
            this.generatePassLabel.Location = new System.Drawing.Point(6, 19);
            this.generatePassLabel.Name = "generatePassLabel";
            this.generatePassLabel.Size = new System.Drawing.Size(212, 15);
            this.generatePassLabel.TabIndex = 9;
            this.generatePassLabel.Text = "Generate Passwords for selected ROWS";
            // 
            // groupBoxPassGen
            // 
            this.groupBoxPassGen.Controls.Add(this.generatePassBnt);
            this.groupBoxPassGen.Controls.Add(this.generatePassLabel);
            this.groupBoxPassGen.Location = new System.Drawing.Point(12, 333);
            this.groupBoxPassGen.Name = "groupBoxPassGen";
            this.groupBoxPassGen.Size = new System.Drawing.Size(222, 67);
            this.groupBoxPassGen.TabIndex = 10;
            this.groupBoxPassGen.TabStop = false;
            this.groupBoxPassGen.Text = "Password Generator";
            // 
            // generatePassBnt
            // 
            this.generatePassBnt.Location = new System.Drawing.Point(6, 37);
            this.generatePassBnt.Name = "generatePassBnt";
            this.generatePassBnt.Size = new System.Drawing.Size(75, 23);
            this.generatePassBnt.TabIndex = 11;
            this.generatePassBnt.Text = "Generate";
            this.generatePassBnt.UseVisualStyleBackColor = true;
            this.generatePassBnt.Click += new System.EventHandler(this.generatePassBnt_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.groupBoxPassGen);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.userGrid);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Configurator";
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userGrid)).EndInit();
            this.groupBoxPassGen.ResumeLayout(false);
            this.groupBoxPassGen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private DataGridView userGrid;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewCheckBoxColumn Enabled;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewCheckBoxColumn Encoded;
        private Button saveButton;
        private Label generatePassLabel;
        private GroupBox groupBoxPassGen;
        private Button generatePassBnt;
    }
}