﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    public partial class ChunkControl : UserControl
    {
        public int ChunkID { get; set; }
        public ChunkControl()
        {
            InitializeComponent();
        }
        public void updateView(Chunk chunk)
        {
            textBox.Text = chunk.Text;
            clipboardKHButton.Text = chunk.ClipboardKHook.ToString();
            autoTypeKHButton.Text = chunk.AutoTypeKHook.ToString();
        }
    }
}
