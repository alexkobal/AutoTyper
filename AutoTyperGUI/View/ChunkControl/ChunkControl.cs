using AutoTyperGUI.Model;
using System;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    /// <summary>
    /// Class for the Chunk visualization component
    /// </summary>
    public partial class ChunkControl : UserControl
    {
        /// <summary>
        /// Internal refference to the connected chunk
        /// </summary>
        private Chunk Chunk { get; }

        /// <summary>
        /// Constructor, has to be initialized with the connected Chunk model object refference
        /// </summary>
        /// <param name="chunk">Chunk model refference</param>
        public ChunkControl(Chunk chunk)
        {
            InitializeComponent();
            Chunk = chunk;
        }

        /// <summary>
        /// Update the Chunk View
        /// </summary>
        public void updateView()
        {
            textBox.Text = Chunk.Text;
            clipboardKHButton.Text = Chunk.ClipboardKHook.ToString();
            autoTypeKHButton.Text = Chunk.AutoTypeKHook.ToString();
        }

        /// <summary>
        /// Event handler for keyboard press when the auto typing keyboard hook button is in focus
        /// Sets the keyboard hook to the input key combination if it is valid.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for keyboard press when the copy to clipboard keyboard hook button is in focus
        /// Sets the keyboard hook to the input key combination if it is valid.
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
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

        /// <summary>
        /// Event handler for text changes
        /// Updates the Chunk model's text when the text in the textbox changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            Chunk.Text = textBox.Text;
        }
    }
}
