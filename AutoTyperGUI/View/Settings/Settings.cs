using AutoTyperGUI.Model;
using System;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    public partial class Settings : Form
    {
        private AutoTypeSettings AutoTypeSettings { get; }
        public Settings(AutoTypeSettings autoTypeSettings)
        {
            AutoTypeSettings = autoTypeSettings;
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            wpmTrackBar.Value = AutoTypeSettings.TypingSpeed.WordsPerMin;
            wpmSpeedLabel.Text = wpmTrackBar.Value.ToString();
            if (AutoTypeSettings.StdDeviation == 0)
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
        }

        private void wpmTrackBar_Scroll(object sender, EventArgs e)
        {
            wpmSpeedLabel.Text = wpmTrackBar.Value.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            AutoTypeSettings.TypingSpeed.WordsPerMin = wpmTrackBar.Value;
            if (checkBox1.Checked)
                AutoTypeSettings.StdDeviation = 30;
            else
                AutoTypeSettings.StdDeviation = 0;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
