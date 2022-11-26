using System.Windows.Forms;

namespace AutoTyperGUI.Model
{
    public class HotKey
    {
        public HotKey(ModifierKeys modifierKeys, Keys key)
        {
            ModifierKeys = modifierKeys;
            Key = key;
        }

        public ModifierKeys ModifierKeys { get; set; }
        public Keys Key { get; set; }
        public override string ToString()
        {
            return ModifierKeys.ToString() + "+" + Key;
        }
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
