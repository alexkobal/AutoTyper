using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoTyperGUI.View.Settings;

namespace AutoTyperGUI
{
    public partial class ConfigurationWindow : Form
    {
        private AutoTyper autoTyper = AutoTyper.Instance;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        public ConfigurationWindow()
        {
            InitializeComponent();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                autoTyper.save(saveFileDialog.FileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: Ránézni erre a szarra.
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                autoTyper.open(openFileDialog.FileName);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsform = new Settings();
            settingsform.Visible = true;
        }
    }
}
