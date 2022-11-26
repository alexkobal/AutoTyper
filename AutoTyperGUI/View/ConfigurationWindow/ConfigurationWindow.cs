using AutoTyperGUI.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    /// <summary>
    /// Class for the main configuration window view
    /// </summary>
    public partial class ConfigurationWindow : Form
    {
        /// <summary>
        /// Refference to the AutoTyper model instance
        /// </summary>
        private AutoTyper autoTyper = AutoTyper.Instance;

        /// <summary>
        /// Save File dialog window
        /// </summary>
        private SaveFileDialog saveFileDialog;

        /// <summary>
        /// Open File dialog window
        /// </summary>
        private OpenFileDialog openFileDialog;

        /// <summary>
        /// List of the connected ChunkControl Views
        /// </summary>
        private List<View.ChunkControl> chunkControls;

        /// <summary>
        /// Constructor. Initializes the configuration window
        /// Calls initialization of the ChunkControl views
        /// </summary>
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

        /// <summary>
        /// Event handler for "Save" menu item
        /// Opens a save file dialog
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                autoTyper.save(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Event handler for "Load" menu item
        /// Opens an open file dialog
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                autoTyper.load(openFileDialog.FileName);
            }
            updateView();
        }

        /// <summary>
        /// Event handler for "Settings" menu item
        /// Opens the settings window
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsform = new Settings(autoTyper.TypeSettings);
            settingsform.Visible = true;
        }

        /// <summary>
        /// Updates all ChunkComponent views in the configuration window
        /// </summary>
        private void updateView()
        {
            foreach(var chunkControl in chunkControls)
            {
                chunkControl.updateView();
            }
        }

        /// <summary>
        /// Initialize ChunkControl views based on the model
        /// </summary>
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
