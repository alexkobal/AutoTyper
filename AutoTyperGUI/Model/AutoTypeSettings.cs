using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoTyperGUI
{
    internal class AutoTypeSettings
    {
        public TypingSpeed TypingSpeed { get; set; }
        public int StdDeviation { get; set; }
        public AutoTypeSettings(int charsPerMin = 300, int stdDeviation = 30) // Normal people typing parameters
        {
            TypingSpeed = new TypingSpeed();
            TypingSpeed.CharsPerMin = charsPerMin;
            StdDeviation = stdDeviation;
        }
    }

    internal class TypingSpeed
    {
        private int charsPerMin;
        public TypingSpeed(int charsPerMin = 0)
        {
            this.charsPerMin = charsPerMin;
        }
        public int CharsPerMin
        {
            get { return charsPerMin; }
            set { charsPerMin = value; }
        }
        public int WordsPerMin
        {
            get { return charsPerMin / 5; }
            set { charsPerMin = value * 5; }
        }
        public int MillisecondsPerChar
        {
            get { return 60000 / charsPerMin; }
            set { charsPerMin = 60000 / value; }
        }
        public override string ToString()
        {
            return charsPerMin.ToString();
        }
    }
}
