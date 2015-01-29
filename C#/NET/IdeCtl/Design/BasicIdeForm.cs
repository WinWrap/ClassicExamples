using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinWrap.Basic;
using WinWrap.Basic.Classic;

namespace samp
{
    public class InitializeArgs : EventArgs
    {
        public IBasicNoUI Basic;
    }

    public partial class BasicIdeForm : Form
    {
        public event EventHandler<TextEventArgs> DebugTrace;
        public event EventHandler<InitializeArgs> Initialize;

        public BasicIdeForm(Form parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        public void Trace(TraceConstants trace)
        {
            basicIdeCtl1.Trace(trace);
        }

        private void basicIdeCtl1_DebugTrace(object sender, WinWrap.Basic.Classic.TextEventArgs e)
        {
            if (DebugTrace != null)
                DebugTrace(this, e);
        }

        private void BasicIdeForm_Load(object sender, EventArgs e)
        {
            basicIdeCtl1.AddExtension("$Feature WWB-COM True", null);

            InitializeArgs args = new InitializeArgs();
            args.Basic = basicIdeCtl1;
            Initialize(this, args);
        }
    }
}