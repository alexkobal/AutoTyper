namespace AutoTyperGUI
{
    partial class ConfigurationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.applyButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chunkControl1 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl2 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl3 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl4 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl5 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl6 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl7 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl8 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl9 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl10 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl11 = new AutoTyperGUI.View.ChunkControl();
            this.chunkControl12 = new AutoTyperGUI.View.ChunkControl();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.applyButton, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 337);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyButton.Location = new System.Drawing.Point(511, 306);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(91, 28);
            this.applyButton.TabIndex = 0;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.chunkControl1);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl2);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl3);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl4);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl5);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl6);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl7);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl8);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl9);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl10);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl11);
            this.flowLayoutPanel1.Controls.Add(this.chunkControl12);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 297);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // chunkControl1
            // 
            this.chunkControl1.Location = new System.Drawing.Point(3, 3);
            this.chunkControl1.Name = "chunkControl1";
            this.chunkControl1.Size = new System.Drawing.Size(537, 213);
            this.chunkControl1.TabIndex = 0;
            // 
            // chunkControl2
            // 
            this.chunkControl2.Location = new System.Drawing.Point(3, 222);
            this.chunkControl2.Name = "chunkControl2";
            this.chunkControl2.Size = new System.Drawing.Size(537, 213);
            this.chunkControl2.TabIndex = 1;
            // 
            // chunkControl3
            // 
            this.chunkControl3.Location = new System.Drawing.Point(3, 441);
            this.chunkControl3.Name = "chunkControl3";
            this.chunkControl3.Size = new System.Drawing.Size(537, 213);
            this.chunkControl3.TabIndex = 2;
            // 
            // chunkControl4
            // 
            this.chunkControl4.Location = new System.Drawing.Point(3, 660);
            this.chunkControl4.Name = "chunkControl4";
            this.chunkControl4.Size = new System.Drawing.Size(537, 213);
            this.chunkControl4.TabIndex = 3;
            // 
            // chunkControl5
            // 
            this.chunkControl5.Location = new System.Drawing.Point(3, 879);
            this.chunkControl5.Name = "chunkControl5";
            this.chunkControl5.Size = new System.Drawing.Size(537, 213);
            this.chunkControl5.TabIndex = 4;
            // 
            // chunkControl6
            // 
            this.chunkControl6.Location = new System.Drawing.Point(3, 1098);
            this.chunkControl6.Name = "chunkControl6";
            this.chunkControl6.Size = new System.Drawing.Size(537, 213);
            this.chunkControl6.TabIndex = 5;
            // 
            // chunkControl7
            // 
            this.chunkControl7.Location = new System.Drawing.Point(3, 1317);
            this.chunkControl7.Name = "chunkControl7";
            this.chunkControl7.Size = new System.Drawing.Size(537, 213);
            this.chunkControl7.TabIndex = 6;
            // 
            // chunkControl8
            // 
            this.chunkControl8.Location = new System.Drawing.Point(3, 1536);
            this.chunkControl8.Name = "chunkControl8";
            this.chunkControl8.Size = new System.Drawing.Size(537, 213);
            this.chunkControl8.TabIndex = 7;
            // 
            // chunkControl9
            // 
            this.chunkControl9.Location = new System.Drawing.Point(3, 1755);
            this.chunkControl9.Name = "chunkControl9";
            this.chunkControl9.Size = new System.Drawing.Size(537, 213);
            this.chunkControl9.TabIndex = 8;
            // 
            // chunkControl10
            // 
            this.chunkControl10.Location = new System.Drawing.Point(3, 1974);
            this.chunkControl10.Name = "chunkControl10";
            this.chunkControl10.Size = new System.Drawing.Size(537, 213);
            this.chunkControl10.TabIndex = 9;
            // 
            // chunkControl11
            // 
            this.chunkControl11.Location = new System.Drawing.Point(3, 2193);
            this.chunkControl11.Name = "chunkControl11";
            this.chunkControl11.Size = new System.Drawing.Size(537, 213);
            this.chunkControl11.TabIndex = 10;
            // 
            // chunkControl12
            // 
            this.chunkControl12.Location = new System.Drawing.Point(3, 2412);
            this.chunkControl12.Name = "chunkControl12";
            this.chunkControl12.Size = new System.Drawing.Size(537, 213);
            this.chunkControl12.TabIndex = 11;
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(605, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "ConfigurationWindow";
            this.Text = "AutoTyper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private View.ChunkControl chunkControl1;
        private View.ChunkControl chunkControl2;
        private View.ChunkControl chunkControl3;
        private View.ChunkControl chunkControl4;
        private View.ChunkControl chunkControl5;
        private View.ChunkControl chunkControl6;
        private View.ChunkControl chunkControl7;
        private View.ChunkControl chunkControl8;
        private View.ChunkControl chunkControl9;
        private View.ChunkControl chunkControl10;
        private View.ChunkControl chunkControl11;
        private View.ChunkControl chunkControl12;
    }
}

