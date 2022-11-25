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
        private List<View.ChunkControl> chunkControls;

        public ConfigurationWindow()
        {
            InitializeComponent();
            initChunkControls();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
            updateView();
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
            updateView();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsform = new Settings();
            settingsform.Visible = true;
        }

        private void updateView()
        {
            for(int i = 0; i < 12; i++)
            {
                this.chunkControls[i].updateView(autoTyper.Chunks[i]);
            }
        }

        private void initChunkControls()
        {
            this.chunkControls = new List<View.ChunkControl>();
            for (int i = 0; i < 12; i++)
            {
                this.chunkControls.Add(new AutoTyperGUI.View.ChunkControl());
                this.chunkControls[i].TabIndex = i;
                this.chunkControls[i].Name = "chunkControl" + i.ToString();
                this.chunkControls[i].Size = new System.Drawing.Size(700, 213);
                this.chunkControls[i].ChunkID = i;
                this.flowLayoutPanel1.Controls.Add(this.chunkControls[i]);
            }
        }
    }
}
