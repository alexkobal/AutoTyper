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
            this.inputTB = new System.Windows.Forms.TextBox();
            this.outputTB = new System.Windows.Forms.TextBox();
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
            this.typeSpeedNumUpDown.Location = new System.Drawing.Point(30, 28);
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
            // inputTB
            // 
            this.inputTB.Location = new System.Drawing.Point(30, 105);
            this.inputTB.Multiline = true;
            this.inputTB.Name = "inputTB";
            this.inputTB.Size = new System.Drawing.Size(267, 371);
            this.inputTB.TabIndex = 2;
            this.inputTB.TextChanged += new System.EventHandler(this.inputTB_TextChanged);
            // 
            // outputTB
            // 
            this.outputTB.Location = new System.Drawing.Point(343, 105);
            this.outputTB.Multiline = true;
            this.outputTB.Name = "outputTB";
            this.outputTB.Size = new System.Drawing.Size(267, 371);
            this.outputTB.TabIndex = 3;
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 583);
            this.Controls.Add(this.outputTB);
            this.Controls.Add(this.inputTB);
            this.Controls.Add(this.typeSpeedNumUpDown);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConfigurationWindow";
            this.Text = "AutoTyper";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeSpeedNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.NumericUpDown typeSpeedNumUpDown;
        private System.Windows.Forms.TextBox inputTB;
        private System.Windows.Forms.TextBox outputTB;
    }
}

