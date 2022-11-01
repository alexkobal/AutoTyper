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
        public double StdDeviation { get; set; }
        public AutoTypeSettings() //TODO add constructor implementation instead of hardcoded values
        {
            TypingSpeed = new TypingSpeed();
            TypingSpeed.CharsPerMin = 280; //Hardcoded my typing speed
            StdDeviation = 3; //Hardcoded my variance
        }
    }

    internal class TypingSpeed
    {
        private int charsPerMin;
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
    }
}
