using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    internal class Chunk
    {
        public string Text { get; set; }
        public KeyboardHook ClipboardKHook { get; private set; }
        public KeyboardHook AutoTypeKHook { get; private set; }
        public AutoTypeSettings TypeSettings { get; private set; }

        public Chunk(string text, KeyboardHook clipboardKHook, KeyboardHook autoTypeKHook, AutoTypeSettings autoTypeSettings)
        {
            this.Text = text;
            this.ClipboardKHook = clipboardKHook;
            this.AutoTypeKHook = autoTypeKHook;
            this.TypeSettings = autoTypeSettings;
            this.ClipboardKHook.KeyPressed += copyToClipboardHandler;
            this.AutoTypeKHook.KeyPressed += autoTypeHandler;
        }

        private void copyToClipboardHandler(object sender, KeyPressedEventArgs e)
        {
            copyToClipboard();
        }

        private void autoTypeHandler(object sender, KeyPressedEventArgs e)
        {
            autoType(TypeSettings);
        }

        private void copyToClipboard()
        {
            Clipboard.SetText(Text);
        }

        private void autoType(AutoTypeSettings settings) // TODO rewrite rand if needed to a more sensible thing
        {
            // TODO type text
        }
    }
}
