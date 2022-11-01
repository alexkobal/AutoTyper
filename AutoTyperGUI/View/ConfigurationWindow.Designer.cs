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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.typeSpeedNumUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeSpeedNumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // typeSpeedNumUpDown
            // 
            this.typeSpeedNumUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.typeSpeedNumUpDown.Location = new System.Drawing.Point(128, 80);
            this.typeSpeedNumUpDown.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.typeSpeedNumUpDown.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.typeSpeedNumUpDown.Name = "typeSpeedNumUpDown";
            this.typeSpeedNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.typeSpeedNumUpDown.TabIndex = 1;
            this.typeSpeedNumUpDown.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.typeSpeedNumUpDown.ValueChanged += new System.EventHandler(this.typeSpeedNumUpDown_ValueChanged);
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 234);
            this.Controls.Add(this.typeSpeedNumUpDown);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigurationWindow";
            this.Text = "AutoTyper";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeSpeedNumUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.NumericUpDown typeSpeedNumUpDown;
    }
}

