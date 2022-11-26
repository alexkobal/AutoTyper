namespace AutoTyperGUI.Model
{
    /// <summary>
    /// Class to represent the parameters of the model
    /// </summary>
    public class AutoTypeSettings
    {
        /// <summary>
        /// Typing speed property
        /// </summary>
        public TypingSpeed TypingSpeed { get; set; }
        /// <summary>
        /// Standard deviation of the typing in cpm (characters per minute)
        /// </summary>
        public int StdDeviation { get; set; }
        /// <summary>
        /// Constructor with initialization possiblility (optional)
        /// </summary>
        /// <param name="charsPerMin"></param>
        /// <param name="stdDeviation"></param>
        public AutoTypeSettings(int charsPerMin = 300, int stdDeviation = 30) // Normal people typing parameters
        {
            TypingSpeed = new TypingSpeed();
            TypingSpeed.CharsPerMin = charsPerMin;
            StdDeviation = stdDeviation;
        }
    }
    /// <summary>
    /// Class to represent the typing speed
    /// </summary>
    public class TypingSpeed
    {
        private int charsPerMin;
        /// <summary>
        /// Constructor for possible initialization of the typing speed (optional)
        /// </summary>
        /// <param name="charsPerMin"></param>
        public TypingSpeed(int charsPerMin = 0)
        {
            this.charsPerMin = charsPerMin;
        }

        /// <summary>
        /// Property to access and set the typing speed in cpm (characters per minute)
        /// </summary>
        public int CharsPerMin
        {
            get { return charsPerMin; }
            set { charsPerMin = value; }
        }

        /// <summary>
        /// Property to access and set the typing speed in wpm (words per minute)
        /// Using 1 word = 5 chars convention
        /// </summary>
        public int WordsPerMin
        {
            get { return charsPerMin / 5; }
            set { charsPerMin = value * 5; }
        }

        /// <summary>
        /// Property to access and set the typing speed in ms/c (millisecons per character)
        /// </summary>
        public int MillisecondsPerChar
        {
            get { return 60000 / charsPerMin; }
            set { charsPerMin = 60000 / value; }
        }

        /// <summary>
        /// Get the string represetntation of the TypingSpeed object
        /// </summary>
        /// <returns>string value with typing speed in cpm (characters per minute)</returns>
        public override string ToString()
        {
            return charsPerMin.ToString();
        }
    }
}
