using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTyperGUI
{
    internal class AutoTypeSettings
    {
        public uint CharsPerMin { get; set; }
        public double Randomness { get; set; }
        public AutoTypeSettings() //TODO add constructor implementation instead of hardcoded values
        {
            CharsPerMin = 45;
            Randomness = 0.4;
        }
    }
}
