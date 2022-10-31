using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI
{
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

        public KeyboardHook()
        {
            // register the event of the inner native window.
            _window.KeyPressed += delegate (object sender, KeyPressedEventArgs args)
            {
                if (KeyPressed != null)
                    KeyPressed(this, args);
            };
        }

        public KeyboardHook(ModifierKeys modifier, Keys key) : this()
        {
            this.RegisterHotKey(modifier, key);
        }

        /// <summary>
        /// Registers a hot key in the system.
        /// </summary>
        /// <param name="modifier">The modifiers that are associated with the hot key.</param>
        /// <param name="key">The key itself that is associated with the hot key.</param>
        public void RegisterHotKey(ModifierKeys modifier, Keys key)
        {
            // increment the counter.
            _currentId = _currentId + 1;

            // register the hot key.
            if (!RegisterHotKey(_window.Handle, _currentId, modifier.Value, (uint)key))
                throw new InvalidOperationException("Couldn’t register the hot key.");
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
            return  ((Alt.Value & value)        > 0 ? Alt       : null) +
                    ((Control.Value & value)    > 0 ? Control   : null) +
                    ((Shift.Value & value)      > 0 ? Shift     : null) +
                    ((Win.Value & value)        > 0 ? Win       : null);
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
    }
}
