using System;
using System.Windows.Forms;

namespace AutoTyperGUI.Model
{
    /// <summary>
    /// Class to model the cunks
    /// </summary>
    public class Chunk
    {
        /// <summary>
        /// Char counter to track the character index during automatic typing
        /// </summary>
        private int charCounter;

        /// <summary>
        /// Timer object to provide the tick event for automatic typing
        /// </summary>
        private readonly Timer timer;

        /// <summary>
        /// Random number generator for sampleGaussian function
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// Is set when automatic typing is requested to handle possible changes during automatic typing
        /// </summary>
        private string currentText;

        /// <summary>
        /// Field to store the typing settings refference
        /// </summary>
        private readonly AutoTypeSettings autoTypeSettings;

        /// <summary>
        /// Property to access/set the text of the current Chunk
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Property to access the "Copy to clipboard" keyboard hook of the current Chunk
        /// </summary>
        public KeyboardHook ClipboardKHook { get; }

        /// <summary>
        /// Property to access the "Automatic typing" keyboard hook of the current Chunk
        /// </summary>
        public KeyboardHook AutoTypeKHook { get; }

        /// <summary>
        /// Constructor to provide the required refference values
        /// </summary>
        /// <param name="text">Text of the chunk</param>
        /// <param name="clipboardKHook">Keyboard hook for "copy to clipboard" functionality</param>
        /// <param name="autoTypeKHook">Keyboard hook for "automatic typing" functionality</param>
        /// <param name="autoTypeSettings">Refference to typing settings</param>
        public Chunk(string text, KeyboardHook clipboardKHook, KeyboardHook autoTypeKHook, AutoTypeSettings autoTypeSettings)
        {
            this.Text = text;
            this.ClipboardKHook = clipboardKHook;
            this.AutoTypeKHook = autoTypeKHook;
            this.autoTypeSettings = autoTypeSettings;
            this.ClipboardKHook.KeyPressed += copyToClipboardHandler;
            this.AutoTypeKHook.KeyPressed += autoTypeHandler;
            this.timer = new Timer();
            this.timer.Tick += writeCharOnTick;
            this.charCounter = 0;
            this.random = new Random(Guid.NewGuid().GetHashCode());
        }

        /// <summary>
        /// Stop the automatic typing if it is running
        /// </summary>
        public void CancelTyping()
        {
            timer.Stop();
            charCounter = 0;
        }

        /// <summary>
        /// Event handler for coopy to clipboard functionality
        /// </summary>
        /// <param name="sender">Event setnder object refference</param>
        /// <param name="e">Event arguments</param>
        private void copyToClipboardHandler(object sender, KeyPressedEventArgs e)
        {
            Clipboard.SetText(Text);
        }

        /// <summary>
        /// Event handler for auto typing functionality
        /// </summary>
        /// <param name="sender">Event setnder object refference</param>
        /// <param name="e">Event arguments</param>
        private void autoTypeHandler(object sender, KeyPressedEventArgs e)
        {
            charCounter = 0;
            currentText = Text; //Need to create a checkpoint for the Text, otherwiese can infinetly type into the text window
            timer.Interval = autoTypeSettings.TypingSpeed.MillisecondsPerChar;
            System.Threading.Thread.Sleep(500); //Unnoticable delay for user, but needed for releasing the key
            timer.Start();
        }

        /// <summary>
        /// Internal supporting function to write the next character during auto typing
        /// </summary>
        /// <param name="sender">Event setnder object refference</param>
        /// <param name="e">Event arguments</param>
        private void writeCharOnTick(object sender, EventArgs e)
        {
            if(charCounter >= currentText.Length)
            {
                CancelTyping();
            }
            else
            {
                if (autoTypeSettings.StdDeviation != 0)
                {
                    int randomInterval = (int)sampleGaussian(random,
                        autoTypeSettings.TypingSpeed.MillisecondsPerChar,
                        autoTypeSettings.StdDeviation);
                    if (randomInterval <= 0)
                        randomInterval = autoTypeSettings.TypingSpeed.MillisecondsPerChar;
                    timer.Stop();
                    timer.Interval = randomInterval;
                    timer.Start();
                }
                SendKeys.Send(currentText[charCounter].ToString());
                charCounter++;
            }
        }

        /// <summary>
        /// Sample a random number from a Gaussian distribution function
        /// </summary>
        /// <param name="random">Random number generator</param>
        /// <param name="mean">Mean of the Gaussian distribution function</param>
        /// <param name="stddev">Standard deviation of the Gaussion function</param>
        /// <returns></returns>
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
