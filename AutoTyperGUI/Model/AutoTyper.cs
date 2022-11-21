using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoTyperGUI
{
    internal class AutoTyper
    {
        private KeyboardHook cancelTypingKHook;
        private readonly static AutoTyper instance = new AutoTyper();
        public Chunk[] Chunks { get; private set; }
        public AutoTypeSettings TypeSettings { get; private set; }
        public KeyboardHook CancelTypingKHook
        {
            get { return cancelTypingKHook; }
            set
            {
                if (cancelTypingKHook != null)
                    cancelTypingKHook.Dispose(); // Unregisters the previous keyboard hook if any
                cancelTypingKHook = value;
            }
        }

        private AutoTyper()
        {
            initTestValues();
        }
        public static AutoTyper Instance { get => instance; }

        public void save(string fileName)
        {
            XmlTextWriter xmlTextWriter = new XmlTextWriter(fileName, System.Text.Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("AutoTyper");

            foreach (Chunk chunk in Chunks)
            {
                xmlTextWriter.WriteStartElement("Chunk");
                xmlTextWriter.WriteElementString("Text", chunk.Text);
                xmlTextWriter.WriteElementString("ClipboardHook", chunk.ClipboardKHook.ToString());
                xmlTextWriter.WriteElementString("AutoTypeHook", chunk.AutoTypeKHook.ToString());
                xmlTextWriter.WriteEndElement();
            }

            xmlTextWriter.WriteStartElement("Settings");
            xmlTextWriter.WriteElementString("TypingSpeed", TypeSettings.TypingSpeed.ToString());
            xmlTextWriter.WriteElementString("StdDeviation", TypeSettings.StdDeviation.ToString());
            xmlTextWriter.WriteElementString("CancelTypingKHook", cancelTypingKHook.ToString());
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }

        public void open(string fileName)
        {
            foreach (Chunk chunk in Chunks)
            {
                chunk.AutoTypeKHook = null;
                chunk.ClipboardKHook = null;
            }
            XmlTextReader xmlTextReader = new XmlTextReader(fileName);

            int i = 0;
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "Text")
                {
                    Chunks[i].Text = xmlTextReader.ReadElementString();
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "ClipboardHook")
                {
                    Chunks[i].ClipboardKHook = Chunk.createKeyboardHook(new List<string>(xmlTextReader.ReadElementString().Split('+')));
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "AutoTypeHook")
                {
                    Chunks[i].AutoTypeKHook = Chunk.createKeyboardHook(new List<string>(xmlTextReader.ReadElementString().Split('+')));
                    i++;
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "TypingSpeed")
                {
                    TypeSettings.TypingSpeed.CharsPerMin = Convert.ToInt32(xmlTextReader.ReadElementString());
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "StdDeviation")
                {
                    TypeSettings.StdDeviation = Convert.ToInt32(xmlTextReader.ReadElementString());
                }
                if (xmlTextReader.NodeType == XmlNodeType.Element && xmlTextReader.Name == "StdDeviation")
                {
                    cancelTypingKHook = Chunk.createKeyboardHook(new List<string>(xmlTextReader.ReadElementString().Split('+')));
                }
            }
        }

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
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F1),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F2),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F3),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F4),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F5),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F6),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F7),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F8),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F9),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F10),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F11),
                new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.F12),
            };
            autoTypeKHooks = new KeyboardHook[12]
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

            TypeSettings = new AutoTypeSettings();
            Chunks = new Chunk[12];
            for (int i = 0; i < 12; i++)
            {
                Chunks[i] = new Chunk(textChunks[i], clipboardKHooks[i], autoTypeKHooks[i], TypeSettings);
            }
            CancelTypingKHook = new KeyboardHook(ModifierKeys.Control + ModifierKeys.Shift, Keys.C);
            CancelTypingKHook.KeyPressed += CancelTypingHook_KeyPressed;
        }

        private void CancelTypingHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            foreach (var chunk in Chunks)
            {
                chunk.CancelTyping();
            }
        }
    }
}
