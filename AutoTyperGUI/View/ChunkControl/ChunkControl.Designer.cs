namespace AutoTyperGUI.View
{
    partial class ChunkControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.autotypeLabel = new System.Windows.Forms.Label();
            this.autoTypeKHButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.clipboardKHButton = new System.Windows.Forms.Button();
            this.clipboardLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.autotypeLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.autoTypeKHButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clipboardKHButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.clipboardLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(537, 141);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // autotypeLabel
            // 
            this.autotypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autotypeLabel.AutoSize = true;
            this.autotypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autotypeLabel.Location = new System.Drawing.Point(404, 37);
            this.autotypeLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.autotypeLabel.Name = "autotypeLabel";
            this.autotypeLabel.Size = new System.Drawing.Size(131, 102);
            this.autotypeLabel.TabIndex = 4;
            this.autotypeLabel.Text = "Change \"autotype\" keyboard hook";
            this.autotypeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // autoTypeKHButton
            // 
            this.autoTypeKHButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoTypeKHButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoTypeKHButton.Location = new System.Drawing.Point(404, 3);
            this.autoTypeKHButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.autoTypeKHButton.Name = "autoTypeKHButton";
            this.autoTypeKHButton.Size = new System.Drawing.Size(131, 29);
            this.autoTypeKHButton.TabIndex = 3;
            this.autoTypeKHButton.UseVisualStyleBackColor = true;
            this.autoTypeKHButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.autoTypeKHButton_KeyDown);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(2, 2);
            this.textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.tableLayoutPanel1.SetRowSpan(this.textBox, 2);
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(264, 137);
            this.textBox.TabIndex = 0;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // clipboardKHButton
            // 
            this.clipboardKHButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardKHButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clipboardKHButton.Location = new System.Drawing.Point(270, 3);
            this.clipboardKHButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.clipboardKHButton.Name = "clipboardKHButton";
            this.clipboardKHButton.Size = new System.Drawing.Size(130, 29);
            this.clipboardKHButton.TabIndex = 1;
            this.clipboardKHButton.UseVisualStyleBackColor = true;
            this.clipboardKHButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.clipboardKHButton_KeyDown);
            // 
            // clipboardLabel
            // 
            this.clipboardLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardLabel.AutoSize = true;
            this.clipboardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clipboardLabel.Location = new System.Drawing.Point(270, 37);
            this.clipboardLabel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clipboardLabel.Name = "clipboardLabel";
            this.clipboardLabel.Size = new System.Drawing.Size(130, 102);
            this.clipboardLabel.TabIndex = 2;
            this.clipboardLabel.Text = "Change \"copy to clipboard\" keyboard hook";
            this.clipboardLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChunkControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ChunkControl";
            this.Size = new System.Drawing.Size(537, 141);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label autotypeLabel;
        private System.Windows.Forms.Button autoTypeKHButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button clipboardKHButton;
        private System.Windows.Forms.Label clipboardLabel;
    }
}
