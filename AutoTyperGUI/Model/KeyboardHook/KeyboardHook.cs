using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoTyperGUI.Model
{
    /// <summary>
    /// Class for handling keyboard hooks in Win32 API
    /// </summary>
    public sealed class KeyboardHook : IDisposable
    {
        // Registers a hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        // Unregisters the hot key with Windows.
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Represents the window that is used internally to get the messages.
        /// </summary>
        private class Window : NativeWindow, IDisposable
        {
            private static int WM_HOTKEY = 0x0312;

            public Window()
            {
                // create the handle for the window.
                this.CreateHandle(new CreateParams());
            }

            /// <summary>
            /// Overridden to get the notifications.
            /// </summary>
            /// <param name="m"></param>
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);

                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    ModifierKeys modifier = (ModifierKeys)((uint)(int)m.LParam & 0xFFFF);

                    // invoke the event to notify the parent.
                    if (KeyPressed != null)
                        KeyPressed(this, new KeyPressedEventArgs(modifier, key));
                }
            }

            public event EventHandler<KeyPressedEventArgs> KeyPressed;

            #region IDisposable Members

            public void Dispose()
            {
                this.DestroyHandle();
            }

            #endregion
        }

        private Window _window = new Window();
        private int _currentId;
        private HotKey _hotKey = null;

        /// <summary>
        /// Assigned HotKey property.
        /// If set, the previous value is unregistered
        /// This is the way you can change the assigned HotKey value
        /// </summary>
        public HotKey HotKey
        {
            get { return _hotKey; }
            set 
            {
                if (_hotKey == null && value == null) 
                    return;
                if (value != null)
                {
                    if (_hotKey != null && _hotKey.Equals(value)) 
                        return;
                    try{
                        UnregisterHotKey();
                    }catch(Exception e)
                    {
                       if (_hotKey != null) throw e;
                    }
                    RegisterHotKey(value);
                }
                else if (_hotKey != null && value == null)
                {
                    UnregisterHotKey();
                }
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        private void RegisterHotKey(HotKey hotKey)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            bool t = RegisterHotKey(_window.Handle, _currentId, hotKey.ModifierKeys.Value, (uint)hotKey.Key);
            if (!t)
            {
                string errorM = Win32ErrorHandler.GetLastErrorString();
                //throw new InvalidOperationException("Couldn’t register the hot key: " + HotKey.ToString() + " Error Message: " + errorM);
            }
            else
            {
                _hotKey = hotKey;
            }
                
        }

        /// <summary>
        /// Unregisters the HotKey
        /// If unregistration is successful sets the HotKey value to null
        /// </summary>
        private void UnregisterHotKey()
        {
            bool t = UnregisterHotKey(_window.Handle, _currentId);
            if (!t)
            {
                string errorM = Win32ErrorHandler.GetLastErrorString();
                //throw new InvalidOperationException("Couldn’t unregister the hot key: " + HotKey.ToString() + " Error Message: " + errorM);
            }
            else
            {
                _hotKey = null;
            }
            
        }

        /// <summary>
        /// Get the string representation of the HotKey
        /// </summary>
        /// <returns>The string representation of the HotKey if it is not null. "Error" otherwise</returns>
        public override string ToString()
        {
            if (HotKey != null)
                return HotKey.ToString();
            return "Error";
        }

        /// <summary>
        /// A hot key has been pressed.
        /// </summary>
        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        #region IDisposable Members

        public void Dispose()
        {
            // unregister all the registered hot keys.
            for (int i = _currentId; i > 0; i--)
            {
                UnregisterHotKey(_window.Handle, i);
            }

            // dispose the inner native window.
            _window.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// Event Args for the event that is fired after the hot key has been pressed.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        private ModifierKeys _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(ModifierKeys modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public ModifierKeys Modifier
        {
            get { return _modifier; }
        }

        public Keys Key
        {
            get { return _key; }
        }
    }
}
