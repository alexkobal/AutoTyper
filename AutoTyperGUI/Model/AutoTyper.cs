using AutoTyperGUI.Model.KeyboardHook;
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
            {
                xmlTextWriter.WriteStartElement("AutoTyper");
                {

                    foreach (Chunk chunk in Chunks)
                    {
                        xmlTextWriter.WriteStartElement("Chunk");
                        {
                            xmlTextWriter.WriteElementString("Text", chunk.Text);
                            xmlTextWriter.WriteStartElement("ClipboardKHook");
                            {
                                xmlTextWriter.WriteStartElement("HotKey");
                                {
                                    xmlTextWriter.WriteElementString("ModifierKeys", chunk.ClipboardKHook.HotKey.ModifierKeys.Value.ToString());
                                    xmlTextWriter.WriteElementString("Key", ((int)chunk.ClipboardKHook.HotKey.Key).ToString());
                                }
                                xmlTextWriter.WriteEndElement();
                            }
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteStartElement("AutoTypeKHook");
                            {
                                xmlTextWriter.WriteStartElement("HotKey");
                                {
                                    xmlTextWriter.WriteElementString("ModifierKeys", chunk.AutoTypeKHook.HotKey.ModifierKeys.Value.ToString());
                                    xmlTextWriter.WriteElementString("Key", ((int)chunk.AutoTypeKHook.HotKey.Key).ToString());
                                }
                                xmlTextWriter.WriteEndElement();
                            }
                            xmlTextWriter.WriteEndElement();
                        }
                        xmlTextWriter.WriteEndElement();
                    }

                    xmlTextWriter.WriteStartElement("Settings");
                    {
                        xmlTextWriter.WriteElementString("TypingSpeed", TypeSettings.TypingSpeed.ToString());
                        xmlTextWriter.WriteElementString("StdDeviation", TypeSettings.StdDeviation.ToString());
                    }
                    xmlTextWriter.WriteEndElement();
                }
                xmlTextWriter.WriteEndElement();
            }
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }

        public void open(string fileName)
        {
            XmlTextReader xmlTextReader = new XmlTextReader(fileName);

            int i = 0;
            KeyboardHook currentHook = null;
            ModifierKeys currentModifierKeys = null;
            Keys currentKey = 0;

            while (xmlTextReader.Read())
            {
                switch (xmlTextReader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (xmlTextReader.Name)
                        {
                            case "Chunk":
                                currentHook = null;
                                currentModifierKeys = null;
                                currentKey = 0;
                                break;
                            case "Text":
                                Chunks[i].Text = xmlTextReader.ReadElementString();
                                break;
                            case "ClipboardKHook":
                                currentHook = Chunks[i].ClipboardKHook;
                                break;
                            case "AutoTypeKHook":
                                currentHook = Chunks[i].AutoTypeKHook;
                                break;
                            case "ModifierKeys":
                                currentModifierKeys = (ModifierKeys)Convert.ToUInt32(xmlTextReader.ReadElementString());
                                break;
                            case "Key":
                                currentKey = (Keys)Convert.ToInt32(xmlTextReader.ReadElementString());
                                break;
                            case "TypingSpeed":
                                TypeSettings.TypingSpeed.CharsPerMin = Convert.ToInt32(xmlTextReader.ReadElementString());
                                break;
                            case "StdDeviation":
                                TypeSettings.StdDeviation = Convert.ToInt32(xmlTextReader.ReadElementString());
                                break;
                        }
                        break;
                    case XmlNodeType.EndElement:
                        switch (xmlTextReader.Name)
                        {
                            case "Chunk":
                                i++;
                                break;
                            case "HotKey":
                                currentHook.HotKey = new HotKey(currentModifierKeys, currentKey);
                                break;
                        }
                        break;

                }
            }
        }

        public static KeyboardHook parseHotKey(List<string> keys)
        {
            List<ModifierKeys> modKeys = new List<ModifierKeys>(4);
            List<int> idxs = new List<int>(4);
            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i] == Keys.Alt.ToString())
                {
                    modKeys.Add(ModifierKeys.Alt);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Control.ToString())
                {
                    modKeys.Add(ModifierKeys.Control);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.Shift.ToString())
                {
                    modKeys.Add(ModifierKeys.Shift);
                    idxs.Add(i);
                }
                if (keys[i] == Keys.LWin.ToString())
                {
                    modKeys.Add(ModifierKeys.Win);
                    idxs.Add(i);
                }
            }
            for (int i = 1; i < modKeys.Count; i++)
                modKeys[0] += modKeys[i];
            for (int i = idxs.Count - 1; i >= 0; i--)
                keys.Remove(keys[idxs[i]]);
            if (keys.Count == 1)
                return null;// new KeyboardHook(modKeys[0], (Keys)Enum.Parse(typeof(Keys), keys[0]));
            else
                return null;
        }

        private void initTestValues() //Values are hardcoded for testing
        {
            string[] textChunks;
            HotKey[] clipboardHotKeys;
            HotKey[] autoTypeHotKeys;
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
            clipboardHotKeys = new HotKey[12]
            {
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F1),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F2),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F3),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F4),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F5),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F6),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F7),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F8),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F9),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F10),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F11),
                new HotKey(ModifierKeys.Control + ModifierKeys.Shift, Keys.F12),
            };
            autoTypeHotKeys = new HotKey[12]
            {
                new HotKey(ModifierKeys.Control, Keys.F1),
                new HotKey(ModifierKeys.Control, Keys.F2),
                new HotKey(ModifierKeys.Control, Keys.F3),
                new HotKey(ModifierKeys.Control, Keys.F4),
                new HotKey(ModifierKeys.Control, Keys.F5),
                new HotKey(ModifierKeys.Control, Keys.F6),
                new HotKey(ModifierKeys.Control, Keys.F7),
                new HotKey(ModifierKeys.Control, Keys.F8),
                new HotKey(ModifierKeys.Control, Keys.F9),
                new HotKey(ModifierKeys.Control, Keys.F10),
                new HotKey(ModifierKeys.Control, Keys.F11),
                new HotKey(ModifierKeys.Control, Keys.F12)
            };

            TypeSettings = new AutoTypeSettings();
            Chunks = new Chunk[12];
            for (int i = 0; i < 12; i++)
            {
                var clipboardKHook = new KeyboardHook();
                var autoTypeeKHook = new KeyboardHook();
                clipboardKHook.HotKey = clipboardHotKeys[i];
                autoTypeeKHook.HotKey = autoTypeHotKeys[i];
                Chunks[i] = new Chunk(textChunks[i], clipboardKHook, autoTypeeKHook, TypeSettings);
            }
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
