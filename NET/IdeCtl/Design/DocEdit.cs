using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace samp
{
    public partial class DocEdit : Form
    {
        private Document m_doc;

        public DocEdit(Form parent, Document doc)
        {
            MdiParent = parent;
            InitializeComponent();
            m_doc = doc;
            doc.AddView(this);
        }

        private void DocEdit_MouseClick(object sender, MouseEventArgs e)
        {
            m_doc.ClickEvent(e.X, e.Y);
        }

        private void DocEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool cancel = false;
            m_doc.ClosingEvent(ref cancel);
            e.Cancel = cancel;
        }

        private void DocEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_doc.RemoveView(this);
        }
    }
}