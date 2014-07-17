using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace samp
{
	public delegate void ReceivedDataDelegate(Connection conn, string data);

	/// <summary>
	/// Summary description for Connection.
	/// </summary>
	public class Connection
	{
		private class StateObject
		{
			public byte[] buffer;

			public StateObject(int bufsize)
			{
				buffer = new byte[bufsize];
			}
		}

		private Socket m_socket;
		private int m_id;
		private ReceivedDataDelegate m_recvDelegate;
		private StringBuilder m_sbRecv = new StringBuilder();

		private static int s_id;

		public Socket Socket
		{
			get { return m_socket; }
		}

		public Connection(Socket socket, ReceivedDataDelegate recvDelegate)
		{
			m_id = s_id;
			if (++s_id < 0)
				s_id = 0;

			m_socket = socket;
			m_recvDelegate = recvDelegate;
			Recv_Start();
		}

		public void Close()
		{
			try
			{
				m_socket.Close();
			}
			catch
			{
			}
		}

		public bool Connected
		{
			get { return m_socket.Connected; }
		}

		public int Id
		{
			get { return m_id; }
		}

		public void Recv_Start()
		{
			StateObject so = new StateObject(0x1000);
			m_socket.BeginReceive(so.buffer, 0, so.buffer.Length, 0,
				new AsyncCallback(Recv_Callback), so);
		}

		public void Send(string data)
		{
			if (data == null || data == "")
				return;
											
			ASCIIEncoding encoding = new ASCIIEncoding();
			int send = encoding.GetByteCount(data);
			StateObject so = new StateObject(send+1);
			encoding.GetBytes(data, 0, send, so.buffer, 0);
			so.buffer[send] = 0x1a;
			m_socket.BeginSend(so.buffer, 0, so.buffer.Length, SocketFlags.None,
				new AsyncCallback(Sent_Callback), so);
		}

		private void Recv_Callback(IAsyncResult ar)
		{
			try
			{
				StateObject so = (StateObject)ar.AsyncState;
				int read = m_socket.EndReceive(ar);
				if (read > 0)
				{
					int first = 0;
					for (int i = 0; i < read; ++i)
						if (so.buffer[i] == 0x1a)
						{
							m_sbRecv.Append(Encoding.ASCII.GetString(so.buffer, first, i-first));
							String s = m_sbRecv.ToString();
							m_sbRecv.Length = 0;
							if (s.Length > 0)
								m_recvDelegate(this, s);

							first = i + 1;
						}

					m_sbRecv.Append(Encoding.ASCII.GetString(so.buffer, first, read-first));
				}

				Recv_Start();
			}
			catch
			{
				Close();
			}
		}

		private void Sent_Callback(IAsyncResult ar)
		{
			StateObject so = (StateObject)ar.AsyncState;
		}
	}
}
