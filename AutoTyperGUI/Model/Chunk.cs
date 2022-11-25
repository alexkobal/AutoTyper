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
    public class Chunk
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
        }
        public KeyboardHook AutoTypeKHook
        {
            get { return autoTypeKHook; }
        }

        public AutoTypeSettings TypeSettings { get; private set; }

        public Chunk(string text, KeyboardHook clipboardKHook, KeyboardHook autoTypeKHook, AutoTypeSettings autoTypeSettings)
        {
            this.Text = text;
            this.clipboardKHook = clipboardKHook;
            this.autoTypeKHook = autoTypeKHook;
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
