using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    public partial class ConfigurationWindow : Form
    {
        private AutoTyper autoTyper = AutoTyper.Instance;
        public ConfigurationWindow()
        {
            InitializeComponent();
            typeSpeedNumUpDown.Value = autoTyper.TypeSettings.CharsPerMin;
        }

        private void typeSpeedNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            autoTyper.TypeSettings.CharsPerMin = (int)typeSpeedNumUpDown.Value;
        }
    }
}
