using AutoTyperGUI.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoTyperGUI.View
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
            var settingsform = new Settings(autoTyper.TypeSettings);
            settingsform.Visible = true;
        }

        private void updateView()
        {
            foreach(var chunkControl in chunkControls)
            {
                chunkControl.updateView();
            }
        }

        private void initChunkControls()
        {
            this.chunkControls = new List<View.ChunkControl>();
            for (int i = 0; i < autoTyper.Chunks.Length; i++)
            {
                this.chunkControls.Add(new View.ChunkControl(autoTyper.Chunks[i]));
                this.chunkControls[i].TabIndex = i;
                this.chunkControls[i].Name = "chunkControl" + i.ToString();
                this.chunkControls[i].Size = new System.Drawing.Size(700, 213);
                this.flowLayoutPanel1.Controls.Add(this.chunkControls[i]);
            }
        }
    }
}
