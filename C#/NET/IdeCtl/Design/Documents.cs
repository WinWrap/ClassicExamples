using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace samp
{
    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
    public class Documents : ICollection<Document>
    {
        private App m_app;
        private List<Document> m_docs;

        internal Documents(App app)
        {
            m_app = app;
            m_docs = new List<Document>();
        }

        public Document Add()
        {
            Document doc = new Document(this);
            m_docs.Add(doc);
            return doc;
        }

        public void CloseAll(bool SaveChanges)
        {
            foreach (Document doc in m_docs)
                doc.Close(SaveChanges);
        }

        public Document Open(string FileName)
        {
            Document doc = new Document(this);
            m_docs.Add(doc);
            return doc;
        }

        internal void InternalRemove(Document doc)
        {
            m_docs.Remove(doc);
        }

        #region ICollection<Document> Members

        [ComVisible(false)]
        public void Add(Document item)
        {
            throw new Exception("The method or operation is not supported.");
        }

        public void Clear()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool Contains(Document item)
        {
            return m_docs.Contains(item);
        }

        [ComVisible(false)]
        public void CopyTo(Document[] array, int arrayIndex)
        {
            throw new Exception("The method or operation is not supported.");
        }

        public int Count
        {
            get { return m_docs.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public bool Remove(Document item)
        {
            if (!Contains(item))
                return false;

            item.Close(false);
            return true;
        }

        #endregion

        #region IEnumerable<Document> Members

        public IEnumerator<Document> GetEnumerator()
        {
            return m_docs.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return m_docs.GetEnumerator();
        }

        #endregion
    }
}
