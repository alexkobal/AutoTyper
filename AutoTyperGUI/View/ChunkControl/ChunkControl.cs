using AutoTyperGUI.Model;
using System;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    public partial class ChunkControl : UserControl
    {
        private Chunk Chunk { get; }
        public ChunkControl(Chunk chunk)
        {
            InitializeComponent();
            Chunk = chunk;
        }
        public void updateView()
        {
            textBox.Text = Chunk.Text;
            clipboardKHButton.Text = Chunk.ClipboardKHook.ToString();
            autoTypeKHButton.Text = Chunk.AutoTypeKHook.ToString();
        }

        private void autoTypeKHButton_KeyDown(object sender, KeyEventArgs e)
        {
            // The keycodes are not the same in Keys and in WIN32 api, so values are created based on the bool flags
            var key = e.KeyCode;
            var modifier = (ModifierKeys)((uint)((e.Alt ? 1 : 0) + (e.Control ? 2 : 0) + (e.Shift ? 4 : 0)));

            if (key != Keys.ShiftKey && key != Keys.ControlKey && key != Keys.Alt)
            {
                autoTypeKHButton.Text = modifier.ToString() + "+" + key.ToString();
                autotypeLabel.Focus(); // To unfocus the button after assignment
                Chunk.AutoTypeKHook.HotKey = new HotKey(modifier, key);
            }
        }
        private void clipboardKHButton_KeyDown(object sender, KeyEventArgs e)
        {
            // The keycodes are not the same in Keys and in WIN32 api, so values are created based on the bool flags
            var key = e.KeyCode;
            var modifier = (ModifierKeys)((uint)((e.Alt ? 1 : 0) + (e.Control ? 2 : 0) + (e.Shift ? 4 : 0)));

            if (key != Keys.ShiftKey && key != Keys.ControlKey && key != Keys.Alt)
            {
                clipboardKHButton.Text = modifier.ToString() + "+" + key.ToString();
                clipboardLabel.Focus(); // To unfocus the button after assignment
                Chunk.ClipboardKHook.HotKey = new HotKey(modifier, key);
                clipboardKHButton.Text = Chunk.ClipboardKHook.ToString();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Chunk.Text = textBox.Text;
        }
    }
}
