using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace samp
{
    [ComVisible(true), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface _DocumentEvents
    {
        void Closing(ref bool cancel);
        void New();
    }

    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual),
    ComSourceInterfaces(typeof(_DocumentEvents))]
    public class Document
    {
        internal delegate void DocEventHandler();
        internal delegate void DocClickEventHandler(int x, int y);
        internal event DocClickEventHandler Click;
        internal delegate void DocClosingEventHandler(ref bool cancel);
        internal event DocClosingEventHandler Closing;
        internal event DocEventHandler New;

        private Documents m_docs;
        private List<DocEdit> m_views = new List<DocEdit>();

        public Document(Documents docs)
        {
            m_docs = docs;
            try
            {
                New();
            }
            catch
            {
            }
        }

        public void Close(bool SaveChanges)
        {
            if (SaveChanges)
                Save();

            foreach (DocEdit docedit in m_views)
                docedit.Close();

            if (m_views.Count == 0)
                m_docs.InternalRemove(this);
        }

        public void Save()
        {
        }

        internal void AddView(DocEdit docedit)
        {
            m_views.Add(docedit);
        }

        internal void ClickEvent(int x, int y)
        {
            try
            {
                Click(x, y);
            }
            catch
            {
            }
        }

        internal void ClosingEvent(ref bool cancel)
        {
            try
            {
                Closing(ref cancel);
            }
            catch
            {
            }
        }

        internal void RemoveView(DocEdit docedit)
        {
            m_views.Remove(docedit);
        }
    }
}
