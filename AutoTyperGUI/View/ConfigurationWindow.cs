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
        private bool keyCombButtonPressed = false;
        private object button;
        private List<Keys> keys = new List<Keys>();
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        public ConfigurationWindow()
        {
            InitializeComponent();
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "xml";
            this.KeyPreview = true;
            refreshTextBoxs();
        }

        private void refreshTextBoxs()
        {
            int i = 0;
            foreach (Chunk c in autoTyper.Chunks)
            {
                (this.Controls.Find("chunk" + i + "textBox", true)[0]).Text = c.Text;
                (this.Controls.Find("chunk" + i + "cliptextBox", true)[0]).Text = c.ClipboardKHook.ToString();
                (this.Controls.Find("chunk" + i + "autotextBox", true)[0]).Text = c.AutoTypeKHook.ToString();
                i++;
            }
        }

        private void chunksavebutton_Click(object sender, EventArgs e)
        {
            int idx = (int)Char.GetNumericValue(((Button)sender).Name[5]);
            autoTyper.Chunks[idx].Text = (this.Controls.Find("chunk" + idx + "textBox", true)[0]).Text;
        }

        private void chunkhookutton_Click(object sender, EventArgs e)
        {
            if (!keyCombButtonPressed)
            {
                button = sender;
                keyCombButtonPressed = true;
            }
            else
            {
                if (button.Equals(sender))
                {
                    int idx = (int)Char.GetNumericValue(((Button)sender).Name[5]);
                    if (((Button)sender).Name.Substring(6, 4) == "clip")
                    {
                        autoTyper.Chunks[idx].ClipboardKHook = Chunk.createKeyboardHook(keys);
                        (this.Controls.Find(((Button)sender).Name.Substring(0, 10) + "textBox", true)[0]).Text =
                            (autoTyper.Chunks[idx].ClipboardKHook != null ? autoTyper.Chunks[idx].ClipboardKHook.ToString() : "");
                    }
                    else
                    {
                        autoTyper.Chunks[idx].AutoTypeKHook = Chunk.createKeyboardHook(keys);
                        (this.Controls.Find(((Button)sender).Name.Substring(0, 10) + "textBox", true)[0]).Text =
                            (autoTyper.Chunks[idx].AutoTypeKHook != null ? autoTyper.Chunks[idx].AutoTypeKHook.ToString() : "");
                    }
                    keys.Clear();
                    keyCombButtonPressed = false;
                }
            }
        }

        private void ConfigurationWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyCombButtonPressed)
            {
                if (e.Modifiers != Keys.None)
                    keys.Add(e.Modifiers);
                else
                    keys.Add(e.KeyCode);
            }
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
                refreshTextBoxs();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settingsform = new Settings();
            settingsform.Visible = true;
        }
    }
}
