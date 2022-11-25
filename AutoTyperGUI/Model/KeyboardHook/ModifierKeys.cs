using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTyperGUI
{
    /// <summary>
    /// The class of possible modifiers.
    /// </summary>
    public class ModifierKeys
    {
        private readonly uint _numericValue;
        private readonly string _text;

        private ModifierKeys(uint numericValue, string text)
        {
            _numericValue = numericValue;
            _text = text;
        }

        private static ModifierKeys getByValue(uint value)
        {
            return ((Alt.Value & value) > 0 ? Alt : null) +
                    ((Control.Value & value) > 0 ? Control : null) +
                    ((Shift.Value & value) > 0 ? Shift : null) +
                    ((Win.Value & value) > 0 ? Win : null);
        }

        public uint Value { get { return _numericValue; } }
        public string Text { get { return _text; } }

        public static readonly ModifierKeys Alt = new ModifierKeys(1, "Alt");
        public static readonly ModifierKeys Control = new ModifierKeys(2, "Control");
        public static readonly ModifierKeys Shift = new ModifierKeys(4, "Shift");
        public static readonly ModifierKeys Win = new ModifierKeys(8, "Win");

        public static ModifierKeys operator +(ModifierKeys a, ModifierKeys b)
        {
            if (a != null && b != null)
                return new ModifierKeys(a.Value + b.Value, a.Text + "+" + b.Text);
            else if (a != null)
                return a;
            else if (b != null)
                return b;
            else return null;
        }

        public static explicit operator ModifierKeys(uint i) => getByValue(i);
        public override string ToString() => Text;
        public override bool Equals(object obj)
        {
            ModifierKeys mk = obj as ModifierKeys;
            if (mk != null)
                return false;
            else
                return base.Equals((ModifierKeys)obj) && mk.Value == this.Value;
        }
    }
}
