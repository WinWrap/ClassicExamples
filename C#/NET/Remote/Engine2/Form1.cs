using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
// *** AddBasic: optional
using WinWrap.Basic;
using WinWrap.Basic.Classic;
// ***

namespace samp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private WinWrap.Basic.BasicIdeObj basicIdeObj1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem miFileExit;
		private System.Windows.Forms.MenuItem miTest;
		private System.Windows.Forms.MenuItem miTestRunMsgBox;
		private System.Windows.Forms.MenuItem miRunWait;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnPause;
		private System.Windows.Forms.Button btnEnd;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkAllowRemoteControl;
		private System.Windows.Forms.TextBox txtSynchronize;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtSynchronizing;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;

		int m_port = 1000;
		private System.Windows.Forms.Label lblAddress;
		Socket m_listenSocket;

		public Form1()
		{
            //
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.basicIdeObj1 = new WinWrap.Basic.BasicIdeObj(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miFileExit = new System.Windows.Forms.MenuItem();
            this.miTest = new System.Windows.Forms.MenuItem();
            this.miTestRunMsgBox = new System.Windows.Forms.MenuItem();
            this.miRunWait = new System.Windows.Forms.MenuItem();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSynchronize = new System.Windows.Forms.TextBox();
            this.chkAllowRemoteControl = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSynchronizing = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // basicIdeObj1
            // 
            this.basicIdeObj1.BackColor = System.Drawing.SystemColors.Window;
            this.basicIdeObj1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.basicIdeObj1.SelBackColor = System.Drawing.SystemColors.Highlight;
            this.basicIdeObj1.SelForeColor = System.Drawing.SystemColors.HighlightText;
            this.basicIdeObj1.DebugPrint += new System.EventHandler<WinWrap.Basic.Classic.TextEventArgs>(this.basicIdeObj1_DebugPrint);
            this.basicIdeObj1.Begin += new System.EventHandler<System.EventArgs>(this.basicIdeObj1_Begin);
            this.basicIdeObj1.Pause_ += new System.EventHandler<System.EventArgs>(this.basicIdeObj1_Pause_);
            this.basicIdeObj1.Resume += new System.EventHandler<System.EventArgs>(this.basicIdeObj1_Resume);
            this.basicIdeObj1.Synchronizing += new System.EventHandler<WinWrap.Basic.Classic.SynchronizingEventArgs>(this.basicIdeObj1_Synchronizing);
            this.basicIdeObj1.End += new System.EventHandler<System.EventArgs>(this.basicIdeObj1_End);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.miTest});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miFileExit});
            this.menuItem1.Text = "&File";
            // 
            // miFileExit
            // 
            this.miFileExit.Index = 0;
            this.miFileExit.Text = "E&xit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // miTest
            // 
            this.miTest.Index = 1;
            this.miTest.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTestRunMsgBox,
            this.miRunWait});
            this.miTest.Text = "&Test";
            // 
            // miTestRunMsgBox
            // 
            this.miTestRunMsgBox.Index = 0;
            this.miTestRunMsgBox.Text = "Run MsgBox.bas";
            this.miTestRunMsgBox.Click += new System.EventHandler(this.miTestRunMsgBox_Click);
            // 
            // miRunWait
            // 
            this.miRunWait.Index = 1;
            this.miRunWait.Text = "Run Wait.bas";
            this.miRunWait.Click += new System.EventHandler(this.miRunWait_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblInfo.Location = new System.Drawing.Point(8, 24);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(520, 16);
            this.lblInfo.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(56, 48);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(48, 24);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(120, 48);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(48, 24);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(184, 48);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(48, 24);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "End";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSynchronize);
            this.groupBox1.Location = new System.Drawing.Point(8, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 104);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Synchronize (command from remote)";
            // 
            // txtSynchronize
            // 
            this.txtSynchronize.Location = new System.Drawing.Point(8, 16);
            this.txtSynchronize.Multiline = true;
            this.txtSynchronize.Name = "txtSynchronize";
            this.txtSynchronize.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSynchronize.Size = new System.Drawing.Size(504, 80);
            this.txtSynchronize.TabIndex = 0;
            // 
            // chkAllowRemoteControl
            // 
            this.chkAllowRemoteControl.AutoCheck = false;
            this.chkAllowRemoteControl.Location = new System.Drawing.Point(8, 8);
            this.chkAllowRemoteControl.Name = "chkAllowRemoteControl";
            this.chkAllowRemoteControl.Size = new System.Drawing.Size(160, 16);
            this.chkAllowRemoteControl.TabIndex = 5;
            this.chkAllowRemoteControl.Text = "Allow Remote Control";
            this.chkAllowRemoteControl.Click += new System.EventHandler(this.chkAllowRemoteControl_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSynchronizing);
            this.groupBox2.Location = new System.Drawing.Point(8, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(520, 104);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Synchronizing (response to remote)";
            // 
            // txtSynchronizing
            // 
            this.txtSynchronizing.Location = new System.Drawing.Point(8, 16);
            this.txtSynchronizing.Multiline = true;
            this.txtSynchronizing.Name = "txtSynchronizing";
            this.txtSynchronizing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSynchronizing.Size = new System.Drawing.Size(504, 80);
            this.txtSynchronizing.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(464, 0);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(64, 20);
            this.txtPort.TabIndex = 7;
            this.txtPort.Text = "1000";
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(432, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(168, 8);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(248, 16);
            this.lblAddress.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(536, 305);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chkAllowRemoteControl);
            this.Controls.Add(this.groupBox2);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "C# BasicIdeObj (on a form) - Remote";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		ArrayList m_conns = new ArrayList();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
			Application.Run(new Form1());
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			Exception ex = e.Exception;
			DialogResult result =
				MessageBox.Show(ex.GetType() + "\n\n" + ex.Message + "\n\n" + ex.StackTrace,
				"Unhandled Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
			switch (result)
			{
				case DialogResult.Ignore:
					return;
				case DialogResult.Retry:
					MessageBox.Show("Retry is not supported.");
					break;
			}

			Application.Exit();
		}

		static string GetAddr()
		{
			string addr = "";
			// Then using host name, get the IP address list..
			IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress [] ipaddrs = ipEntry.AddressList;
          
			foreach (IPAddress ipaddr in ipaddrs)
			{
				if (addr != "")
					addr += " ";

				addr += ipaddr.ToString();
			}

			return addr;
		}

		private void Listen_Callback(IAsyncResult ar)
		{
			Socket s = (Socket)ar.AsyncState;
			Socket s2 = s.EndAccept(ar);
			Connection conn = new Connection(s2, new ReceivedDataDelegate(ReceivedDataAsync));
            if (m_conns.Count == 0)
                basicIdeObj1.Synchronized = true;

			m_conns.Add(conn);

			m_listenSocket.BeginAccept(new AsyncCallback(Listen_Callback), m_listenSocket);
		}

		public void ReceivedData(Connection conn, string data)
		{
			txtSynchronize.Text = data;
			basicIdeObj1.Synchronize(data, conn.Id);
		}

		public void ReceivedDataAsync(Connection conn, string data)
		{
			BeginInvoke(new ReceivedDataDelegate(ReceivedData), new object[]{conn, data});
		}

		private void StartListening()
		{
			if (m_listenSocket == null)
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Blocking = false;
				try
				{
					IPEndPoint ep = new IPEndPoint(IPAddress.Any, m_port);
					socket.Bind(ep);
					socket.Listen(5);
					socket.BeginAccept(new AsyncCallback(Listen_Callback), socket);
                    m_listenSocket = socket;
                }
				catch (Exception ex)
				{
					socket.Close();
					MessageBox.Show(ex.Message);
					return;
				}

				chkAllowRemoteControl.Checked = true;
				txtPort.Enabled = false;

				lblInfo.Text = GetAddr();
			}
		}

		private void StopListening()
		{
			if (m_listenSocket != null)
			{
				while (m_conns.Count > 0)
				{
					Connection conn = (Connection)m_conns[0];
					conn.Close();
					m_conns.Remove(conn);
				}

				m_listenSocket.Close();
				m_listenSocket = null;

				chkAllowRemoteControl.Checked = false;
				txtPort.Enabled = true;
				basicIdeObj1.Synchronized = false;

				lblInfo.Text = "Not listening.";
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            // *** AddBasic: required
            // set your Application/Server certificate's secret first
            basicIdeObj1.Initialize();
            // ***

            // *** AddBasic: optional
			// turn on tracing
			basicIdeObj1.Trace(TraceConstants.All&~TraceConstants.QueryEvent);
			// ***

			// *** AddBasic: recommended
			// manage the Basic object/control using this form
			basicIdeObj1.AttachToForm(this, ManageConstants.All);
			// ***

			basicIdeObj1.Code =
				"Sub Main\r\n" +
				"\tV = \"Before Wait\"\r\n" +
				"\tDebug.Print \"Waiting for 5 seconds...\"\r\n" +
				"\tWait 5\r\n" +
				"\tV = \"After Wait\"\r\n" +
				"\tMsgBox \"Hello World!\"\r\n" +
				"End Sub";

			lblAddress.Text = GetAddr();
			lblInfo.Text = "Idle.";

			BeginInvoke(new MethodInvoker(StartListening));
		}

		private void miFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void miTestRunMsgBox_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			basicIdeObj1.RunFile("\"" + Application.ExecutablePath + "\\..\\..\\..\\msgbox.bas\"");
			// ***
		}

		private void miRunWait_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			basicIdeObj1.RunFile("\"" + Application.ExecutablePath + "\\..\\..\\..\\wait.bas\"");
			// ***
		}

		private void basicIdeObj1_DebugPrint(object sender, WinWrap.Basic.Classic.TextEventArgs e)
		{
			lblInfo.Text = e.Text;
		}

		private void basicIdeObj1_Begin(object sender, System.EventArgs e)
		{
			lblInfo.Text = "Running...";
			btnRun.Enabled = false;
			btnPause.Enabled = true;
			btnEnd.Enabled = true;
		}

		private void basicIdeObj1_End(object sender, System.EventArgs e)
		{
			lblInfo.Text = "Idle.";
			btnRun.Enabled = true;
			btnPause.Enabled = false;
			btnEnd.Enabled = false;
		}

		private void basicIdeObj1_Pause_(object sender, System.EventArgs e)
		{
			lblInfo.Text = "Paused.";
			btnRun.Enabled = true;
			btnPause.Enabled = false;
			btnEnd.Enabled = true;
		}

		private void basicIdeObj1_Resume(object sender, System.EventArgs e)
		{
			lblInfo.Text = "Resuming...";
			btnRun.Enabled = false;
			btnPause.Enabled = true;
			btnEnd.Enabled = true;
		}

		private void basicIdeObj1_Synchronizing(object sender, WinWrap.Basic.Classic.SynchronizingEventArgs e)
		{
			txtSynchronizing.Text = e.Param;
			// send to all connections
			for (int i = 0; i < m_conns.Count; ++i)
			{
				Connection conn = (Connection)m_conns[i];
                if (conn.Connected)
                {
                    if (e.Id == -1 || e.Id == conn.Id)
                        conn.Send(e.Param);
                }
                else
                {
                    m_conns.Remove(conn);
                    --i;
                }
			}

            if (m_conns.Count == 0)
            {
                basicIdeObj1.Synchronized = false;
                lblInfo.Text = "All connections closed.";
            }
		}

		private void chkAllowRemoteControl_Click(object sender, System.EventArgs e)
		{
			if (m_listenSocket != null)
				StopListening();
			else
				StartListening();
		}

		private void btnRun_Click(object sender, System.EventArgs e)
		{
			if (basicIdeObj1.Pause)
				basicIdeObj1.Pause = false;
			else
				basicIdeObj1.Run = true;
		}

		private void btnPause_Click(object sender, System.EventArgs e)
		{
			basicIdeObj1.Pause = true;
		}

		private void btnEnd_Click(object sender, System.EventArgs e)
		{
			basicIdeObj1.Run = false;
		}

		private void txtPort_TextChanged(object sender, System.EventArgs e)
		{
			m_port = int.Parse(txtPort.Text);
		}
	}
}
