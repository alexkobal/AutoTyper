using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI.View.Settings
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            trackBar1.Value = AutoTyper.Instance.TypeSettings.TypingSpeed.WordsPerMin;
            label3.Text = trackBar1.Value.ToString();
            if (AutoTyper.Instance.TypeSettings.StdDeviation == 0)
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            AutoTyper.Instance.TypeSettings.TypingSpeed.WordsPerMin = trackBar1.Value;
            if (checkBox1.Checked)
                AutoTyper.Instance.TypeSettings.StdDeviation = 30;
            else
                AutoTyper.Instance.TypeSettings.StdDeviation = 0;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
