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
        private int charCounter;
        private Timer timer;

        public Chunk(string text, KeyboardHook clipboardKHook, KeyboardHook autoTypeKHook, AutoTypeSettings autoTypeSettings)
        {
            this.Text = text;
            this.ClipboardKHook = clipboardKHook;
            this.AutoTypeKHook = autoTypeKHook;
            this.TypeSettings = autoTypeSettings;
            this.ClipboardKHook.KeyPressed += copyToClipboardHandler;
            this.AutoTypeKHook.KeyPressed += autoTypeHandler;
            this.timer = new Timer();
            this.charCounter = 0;
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

        private void autoType(AutoTypeSettings settings)
        {
            charCounter = 0;
            timer.Interval = 60 * 1000 / settings.CharsPerMin;
            timer.Tick += writeCharOnTick;
            timer.Start();
        }

        private void writeCharOnTick(object sender, EventArgs e)
        {
            if(charCounter >= Text.Length)
            {
                CancelTyping();
            }
            else
            {
                SendKeys.Send(Text[charCounter].ToString());
                charCounter++;
            }
        }

        public void CancelTyping()
        {
            timer.Stop();
            charCounter = 0;
        }
    }
}
