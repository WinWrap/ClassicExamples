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
    public partial class MdiForm : Form
    {
        private BasicIdeForm basicIdeForm;
        private BasicTraceForm basicTraceForm;

        private App m_app;

        public MdiForm()
        {
            InitializeComponent();
            m_app = new App(this);
        }

        void basicIdeForm_Initialize(object sender, InitializeArgs e)
        {
            e.Basic.AddExtension("{}", m_app);
            e.Basic.AddExtension("-", m_app);
            e.Basic.AddExtension(".App.", m_app);
        }

        public App App
        {
            get { return m_app; }
        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = m_app.Documents.Add();
            DocEdit docedit = new DocEdit(this, doc);
            docedit.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void basicEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (basicIdeForm == null)
            {
                basicIdeForm = new BasicIdeForm(this);
                basicIdeForm.DebugTrace += new EventHandler<TextEventArgs>(basicIdeForm_DebugTrace);
                if (basicTraceForm != null)
                    basicIdeForm.Trace(TraceConstants.All);

                basicIdeForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(basicIdeForm_FormClosed);
                basicIdeForm.Initialize += new EventHandler<InitializeArgs>(basicIdeForm_Initialize);
            }

            basicIdeForm.Show();
        }

        private void basicIdeForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            basicIdeForm = null;
            if (basicTraceForm != null)
                basicTraceForm.Close();
        }

        private void basicIdeForm_DebugTrace(object sender, TextEventArgs e)
        {
            if (basicTraceForm != null)
                basicTraceForm.AppendLine(e.Text);
        }

        private void basicTraceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (basicTraceForm == null)
            {
                basicTraceForm = new BasicTraceForm(this);
                basicTraceForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(basicTraceForm_FormClosed);
                if (basicIdeForm != null)
                    basicIdeForm.Trace(TraceConstants.All);
            }

            basicTraceForm.Show();
        }

        private void basicTraceForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            basicTraceForm = null;
            if (basicIdeForm != null)
                basicIdeForm.Trace(TraceConstants.None);
        }
    }
}