namespace AutoTyperGUI.Model
{
    /// <summary>
    /// The class of possible modifiers.
    /// </summary>
    public class ModifierKeys
    {
        private readonly uint _numericValue;
        private readonly string _text;

        /// <summary>
        /// Private constructor that sets the modifier key values
        /// Not accessible from outside because there is a limited veriety of possible values
        /// </summary>
        /// <param name="numericValue"></param>
        /// <param name="text"></param>
        private ModifierKeys(uint numericValue, string text)
        {
            _numericValue = numericValue;
            _text = text;
        }

        /// <summary>
        /// Creates a ModifyerKey object from a uint value (based on bit flags)
        /// Internal function, used for cast operator
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static ModifierKeys getByValue(uint value)
        {
            return ((Alt.Value & value) > 0 ? Alt : null) +
                    ((Control.Value & value) > 0 ? Control : null) +
                    ((Shift.Value & value) > 0 ? Shift : null) +
                    ((Win.Value & value) > 0 ? Win : null);
        }

        /// <summary>
        /// Property to access the numeric value of the modifyer key
        /// </summary>
        public uint Value { get { return _numericValue; } }

        /// <summary>
        /// Property to access the string representation of the modifyer key
        /// </summary>
        public string Text { get { return _text; } }

        /// <summary>
        /// Alt ModifyerKey value
        /// </summary>
        public static readonly ModifierKeys Alt = new ModifierKeys(1, "Alt");

        /// <summary>
        /// Control ModifyerKey value
        /// </summary>
        public static readonly ModifierKeys Control = new ModifierKeys(2, "Control");

        /// <summary>
        /// Shift ModifyerKey value
        /// </summary>
        public static readonly ModifierKeys Shift = new ModifierKeys(4, "Shift");

        /// <summary>
        /// Win ModifyerKey value
        /// </summary>
        public static readonly ModifierKeys Win = new ModifierKeys(8, "Win");

        /// <summary>
        /// Combines two modifyer keys
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ModifierKeys operator +(ModifierKeys a, ModifierKeys b)
        {
            if (a != null && b != null)
                return new ModifierKeys(a.Value | b.Value, a.Text + "+" + b.Text);
            else if (a != null)
                return a;
            else if (b != null)
                return b;
            else return null;
        }

        /// <summary>
        /// Casts a uint value to ModifyerKeys object
        /// </summary>
        /// <param name="i"></param>
        public static explicit operator ModifierKeys(uint i) => getByValue(i);

        /// <summary>
        /// Gets the string representation of the ModifyerKeys object
        /// </summary>
        /// <returns>String representation of the ModifyerKeys object in form of "[Modifyer]+[Modifyer]+[Modifyer]"</returns>
        public override string ToString() => Text;

        /// <summary>
        /// Determins if two ModifyerKeys objects are equal (in value)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            ModifierKeys mk = obj as ModifierKeys;
            if (mk == null)
                return false;
            else
                return base.Equals((ModifierKeys)obj) || mk.Value == this.Value;
        }
    }
}
