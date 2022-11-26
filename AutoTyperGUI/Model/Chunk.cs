using System;
using System.Windows.Forms;

namespace AutoTyperGUI.Model
{
    public class Chunk
    {
        private int charCounter;
        private readonly Timer timer;
        private readonly Random random;
        private string currentText;
        public string Text { get; set; }
        public KeyboardHook ClipboardKHook { get; }
        public KeyboardHook AutoTypeKHook { get; }

        public AutoTypeSettings TypeSettings { get; }

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
            currentText = Text; //Need to create a checkpoint for the Text, otherwiese can infinetly type into the text window
            timer.Interval = TypeSettings.TypingSpeed.MillisecondsPerChar;
            System.Threading.Thread.Sleep(500); //Unnoticable delay for user, but needed for releasing the key
            timer.Start();
        }

        private void writeCharOnTick(object sender, EventArgs e)
        {
            if(charCounter >= currentText.Length)
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
                SendKeys.Send(currentText[charCounter].ToString());
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
