using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace samp
{
    public partial class BasicTraceForm : Form
    {
        public BasicTraceForm(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        public void AppendLine(string text)
        {
            textBox1.AppendText(text + "\r\n");
        }
    }
}