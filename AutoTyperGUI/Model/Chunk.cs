using AutoTyperGUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    internal class Chunk
    {
        private KeyboardHook clipboardKHook;
        private KeyboardHook autoTypeKHook;
        private int charCounter;
        private Timer timer;
        private Random random;
        public string Text { get; set; }
        public KeyboardHook ClipboardKHook 
        {
            get { return clipboardKHook; }
            set
            {
                if(clipboardKHook != null)
                    clipboardKHook.Dispose(); // Unregisters the previous keyboard hook if any
                clipboardKHook = value;
            }
        }
        public KeyboardHook AutoTypeKHook
        {
            get { return autoTypeKHook; }
            set
            {
                if(autoTypeKHook != null)
                    autoTypeKHook.Dispose(); // Unregisters the previous keyboard hook if any
                autoTypeKHook = value;
            }
        }
        public static KeyboardHook createKeyboardHook(List<string> keys)
        {
            List<ModifierKeys> modKeys = new List<ModifierKeys>(4);
            List<int> idxs = new List<int>(4);
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == Keys.Alt.ToString())
                {
                    modKeys.Add(ModifierKeys.Alt);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Control.ToString())
                {
                    modKeys.Add(ModifierKeys.Control);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Shift.ToString())
                {
                    modKeys.Add(ModifierKeys.Shift);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.LWin.ToString())
                {
                    modKeys.Add(ModifierKeys.Win);
                    idxs.Add(i);
                }
            }
            for (int i = 1; i < modKeys.Count; i++)
                modKeys[0] += modKeys[i];
            for (int i = idxs.Count - 1; i >= 0; i--)
                keys.Remove(keys[idxs[i]]);
            if (keys.Count == 1)
                return new KeyboardHook(modKeys[0], (Keys)Enum.Parse(typeof(Keys), keys[0]));
            else
                return null;
        }
        public static KeyboardHook createKeyboardHook(List<Keys> keys)
        {
            List<ModifierKeys> modKeys = new List<ModifierKeys>(4);
            List<int> idxs = new List<int>(4);
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == Keys.Alt)
                {
                    modKeys.Add(ModifierKeys.Alt);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Control)
                {
                    modKeys.Add(ModifierKeys.Control);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Shift)
                {
                    modKeys.Add(ModifierKeys.Shift);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.LWin)
                {
                    modKeys.Add(ModifierKeys.Win);
                    idxs.Add(i);
                }
            }
            for (int i = 1; i < modKeys.Count; i++)
                modKeys[0] += modKeys[i];
            for (int i = idxs.Count - 1; i >= 0; i--)
                keys.Remove(keys[idxs[i]]);
            if (keys.Count == 1)
                return new KeyboardHook(modKeys[0], keys[0]);
            else
                return null;
        }
        public AutoTypeSettings TypeSettings { get; private set; }

        public Chunk(string text, KeyboardHook clipboardKHook, KeyboardHook autoTypeKHook, AutoTypeSettings autoTypeSettings)
        {
            this.Text = text;
            this.ClipboardKHook = clipboardKHook;
            this.AutoTypeKHook = autoTypeKHook;
            this.TypeSettings = autoTypeSettings;
            this.ClipboardKHook.KeyPressed += copyToClipboardHandler;
            this.AutoTypeKHook.KeyPressed += autoTypeHandler;
            this.timer = new Timer();
            this.timer.Tick += writeCharOnTick;
            this.charCounter = 0;
            this.random = new Random(Guid.NewGuid().GetHashCode());
        }

        public void CancelTyping()
        {
            timer.Stop();
            charCounter = 0;
        }

        private void copyToClipboardHandler(object sender, KeyPressedEventArgs e)
        {
            Clipboard.SetText(Text);
        }

        private void autoTypeHandler(object sender, KeyPressedEventArgs e)
        {
            charCounter = 0;
            timer.Interval = TypeSettings.TypingSpeed.MillisecondsPerChar;
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
                if (TypeSettings.StdDeviation != 0)
                {
                    int randomInterval = (int)sampleGaussian(random,
                        TypeSettings.TypingSpeed.MillisecondsPerChar,
                        TypeSettings.StdDeviation);
                    if (randomInterval <= 0)
                        randomInterval = TypeSettings.TypingSpeed.MillisecondsPerChar;
                    timer.Stop();
                    timer.Interval = randomInterval;
                    timer.Start();
                }
                SendKeys.Send(Text[charCounter].ToString());
                charCounter++;
            }
        }

        private double sampleGaussian(Random random, double mean, double stddev)
        {
            // The method requires sampling from a uniform random of (0,1]
            // but Random.NextDouble() returns a sample of [0,1).
            double x1 = 1 - random.NextDouble();
            double x2 = 1 - random.NextDouble();

            double y1 = Math.Sqrt(-2.0 * Math.Log(x1)) * Math.Cos(2.0 * Math.PI * x2);
            return y1 * stddev + mean;
        }
    }
}
