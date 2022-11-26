using System.Windows.Forms;

namespace AutoTyperGUI.Model
{
    /// <summary>
    /// Represents a HotKey structure containing ModifierKeys and one Key
    /// </summary>
    public class HotKey
    {
        /// <summary>
        /// Constructor for creating a Hotkey
        /// </summary>
        /// <param name="modifierKeys"></param>
        /// <param name="key"></param>
        public HotKey(ModifierKeys modifierKeys, Keys key)
        {
            ModifierKeys = modifierKeys;
            Key = key;
        }
        /// <summary>
        /// ModifierKeys can be accessed and changed
        /// </summary>
        public ModifierKeys ModifierKeys { get; set; }
        /// <summary>
        /// Key can be accessed and changed
        /// </summary>
        public Keys Key { get; set; }
        /// <summary>
        /// Returns the string representation of HotKey object
        /// </summary>
        /// <returns>string in form of [ModifyerKeys]+[Key}</returns>
        public override string ToString()
        {
            return ModifierKeys.ToString() + "+" + Key;
        }
        /// <summary>
        /// Checks the equality of objects (based on their value)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true if the objects are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            HotKey hk = obj as HotKey;
            if (hk == null)
                return false;
            else
                return base.Equals((HotKey)obj) || hk.Key.Equals(this.Key) && hk.ModifierKeys.Equals(this.ModifierKeys);
        }
    }
}
