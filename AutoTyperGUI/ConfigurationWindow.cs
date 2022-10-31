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
        private int testCounter = 0;
        public ConfigurationWindow()
        {
            InitializeComponent();
            KeyboardHook hook = new KeyboardHook();
            hook.RegisterHotKey(AutoTyperGUI.ModifierKeys.Shift + AutoTyperGUI.ModifierKeys.Control, Keys.F1);
            hook.KeyPressed += WriteCounter;
        }

        private void WriteCounter(object sender, KeyPressedEventArgs e)
        {
            testCounter++;
            testTextBox.Text = e.Modifier.ToString() + "+" + e.Key.ToString() + " counter: " + testCounter.ToString();
        }
    }
}
