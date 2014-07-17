using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace samp
{
    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
    public class App
    {
        private MdiForm m_mdiform;
        private Documents m_docs;

        internal App(MdiForm mdiform)
        {
            m_mdiform = mdiform;
            m_docs = new Documents(this);
        }

        public Documents Documents
        {
            get { return m_docs; }
        }
    }
}
