using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    internal class AutoTyper
    {
        private readonly static AutoTyper instance = new AutoTyper();
        public Chunk[] Chunks { get; private set; }

        private AutoTyper()
        {
            initTestValues();
        }
        public static AutoTyper Instance { get => instance; }

        private void initTestValues() //Values are hardcoded for testing
        {
            string[] textChunks;
            KeyboardHook[] clipboardKHooks;
            KeyboardHook[] autoTypeKHooks;
            textChunks = new string[12]
            {
                "Text1",
                "Text2",
                "Text3",
                "Text4",
                "Text5",
                "Text6",
                "Text7",
                "Text8",
                "Text9",
                "Text10",
                "Text11",
                "Text12",
            };
            clipboardKHooks = new KeyboardHook[12]
            {
                new KeyboardHook(ModifierKeys.Control, Keys.F1),
                new KeyboardHook(ModifierKeys.Control, Keys.F2),
                new KeyboardHook(ModifierKeys.Control, Keys.F3),
                new KeyboardHook(ModifierKeys.Control, Keys.F4),
                new KeyboardHook(ModifierKeys.Control, Keys.F5),
                new KeyboardHook(ModifierKeys.Control, Keys.F6),
                new KeyboardHook(ModifierKeys.Control, Keys.F7),
                new KeyboardHook(ModifierKeys.Control, Keys.F8),
                new KeyboardHook(ModifierKeys.Control, Keys.F9),
                new KeyboardHook(ModifierKeys.Control, Keys.F10),
                new KeyboardHook(ModifierKeys.Control, Keys.F11),
                new KeyboardHook(ModifierKeys.Control, Keys.F12),
            };
            autoTypeKHooks = new KeyboardHook[12]
            {
                new KeyboardHook(ModifierKeys.Shift, Keys.F1),
                new KeyboardHook(ModifierKeys.Shift, Keys.F2),
                new KeyboardHook(ModifierKeys.Shift, Keys.F3),
                new KeyboardHook(ModifierKeys.Shift, Keys.F4),
                new KeyboardHook(ModifierKeys.Shift, Keys.F5),
                new KeyboardHook(ModifierKeys.Shift, Keys.F6),
                new KeyboardHook(ModifierKeys.Shift, Keys.F7),
                new KeyboardHook(ModifierKeys.Shift, Keys.F8),
                new KeyboardHook(ModifierKeys.Shift, Keys.F9),
                new KeyboardHook(ModifierKeys.Shift, Keys.F10),
                new KeyboardHook(ModifierKeys.Shift, Keys.F11),
                new KeyboardHook(ModifierKeys.Shift, Keys.Q),
            };

            AutoTypeSettings autoTypeSettings = new AutoTypeSettings();
            Chunks = new Chunk[12];
            for (int i = 0; i < 12; i++)
            {
                Chunks[i] = new Chunk(textChunks[i], clipboardKHooks[i], autoTypeKHooks[i], autoTypeSettings);
            }
        }
    }
}
