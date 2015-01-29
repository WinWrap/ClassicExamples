using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
// *** AddBasic: optional
using Microsoft.Win32;
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
        private System.Windows.Forms.TextBox txtTrace;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miTrace;
		private System.Windows.Forms.MenuItem miTraceAction;
		private System.Windows.Forms.MenuItem miTraceQuery;
		private System.Windows.Forms.MenuItem miTraceActionEvent;
		private System.Windows.Forms.MenuItem miTraceQueryEvent;
		private System.Windows.Forms.MenuItem miTraceInternal;
		private System.Windows.Forms.MenuItem miTraceExecution;
		private System.Windows.Forms.MenuItem miTraceSep1;
		private System.Windows.Forms.MenuItem miTraceNone;
		private System.Windows.Forms.MenuItem miTraceAll;
		private System.Windows.Forms.MenuItem miTraceSep2;
		private System.Windows.Forms.MenuItem miTraceClear;
		private System.ComponentModel.IContainer components;

        private BasicIdeObj basicIdeObj1;
		private Connection m_conn;

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
            this.txtTrace = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.miTrace = new System.Windows.Forms.MenuItem();
            this.miTraceAction = new System.Windows.Forms.MenuItem();
            this.miTraceQuery = new System.Windows.Forms.MenuItem();
            this.miTraceActionEvent = new System.Windows.Forms.MenuItem();
            this.miTraceQueryEvent = new System.Windows.Forms.MenuItem();
            this.miTraceInternal = new System.Windows.Forms.MenuItem();
            this.miTraceExecution = new System.Windows.Forms.MenuItem();
            this.miTraceSep1 = new System.Windows.Forms.MenuItem();
            this.miTraceNone = new System.Windows.Forms.MenuItem();
            this.miTraceAll = new System.Windows.Forms.MenuItem();
            this.miTraceSep2 = new System.Windows.Forms.MenuItem();
            this.miTraceClear = new System.Windows.Forms.MenuItem();
            this.basicIdeObj1 = new WinWrap.Basic.BasicIdeObj(this.components);
            this.SuspendLayout();
            // 
            // txtTrace
            // 
            this.txtTrace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrace.BackColor = System.Drawing.Color.Black;
            this.txtTrace.ForeColor = System.Drawing.Color.Lime;
            this.txtTrace.Location = new System.Drawing.Point(0, 0);
            this.txtTrace.Multiline = true;
            this.txtTrace.Name = "txtTrace";
            this.txtTrace.ReadOnly = true;
            this.txtTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTrace.Size = new System.Drawing.Size(560, 144);
            this.txtTrace.TabIndex = 1;
            this.txtTrace.WordWrap = false;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTrace});
            // 
            // miTrace
            // 
            this.miTrace.Index = 0;
            this.miTrace.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miTraceAction,
            this.miTraceQuery,
            this.miTraceActionEvent,
            this.miTraceQueryEvent,
            this.miTraceInternal,
            this.miTraceExecution,
            this.miTraceSep1,
            this.miTraceNone,
            this.miTraceAll,
            this.miTraceSep2,
            this.miTraceClear});
            this.miTrace.MergeOrder = 45;
            this.miTrace.MergeType = System.Windows.Forms.MenuMerge.MergeItems;
            this.miTrace.Text = "&Trace";
            // 
            // miTraceAction
            // 
            this.miTraceAction.Checked = true;
            this.miTraceAction.Index = 0;
            this.miTraceAction.Text = "&Action (propert set or method call)";
            this.miTraceAction.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceQuery
            // 
            this.miTraceQuery.Checked = true;
            this.miTraceQuery.Index = 1;
            this.miTraceQuery.Text = "&Query (property get)";
            this.miTraceQuery.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceActionEvent
            // 
            this.miTraceActionEvent.Checked = true;
            this.miTraceActionEvent.Index = 2;
            this.miTraceActionEvent.Text = "Action &Event";
            this.miTraceActionEvent.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceQueryEvent
            // 
            this.miTraceQueryEvent.Index = 3;
            this.miTraceQueryEvent.Text = "Query &Event";
            this.miTraceQueryEvent.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceInternal
            // 
            this.miTraceInternal.Checked = true;
            this.miTraceInternal.Index = 4;
            this.miTraceInternal.Text = "&Internal";
            this.miTraceInternal.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceExecution
            // 
            this.miTraceExecution.Checked = true;
            this.miTraceExecution.Index = 5;
            this.miTraceExecution.Text = "&Execution";
            this.miTraceExecution.Click += new System.EventHandler(this.miTraceToggle_Click);
            // 
            // miTraceSep1
            // 
            this.miTraceSep1.Index = 6;
            this.miTraceSep1.Text = "-";
            // 
            // miTraceNone
            // 
            this.miTraceNone.Index = 7;
            this.miTraceNone.Text = "&None";
            this.miTraceNone.Click += new System.EventHandler(this.miTraceNone_Click);
            // 
            // miTraceAll
            // 
            this.miTraceAll.Index = 8;
            this.miTraceAll.Text = "A&ll";
            this.miTraceAll.Click += new System.EventHandler(this.miTraceAll_Click);
            // 
            // miTraceSep2
            // 
            this.miTraceSep2.Index = 9;
            this.miTraceSep2.Text = "-";
            // 
            // miTraceClear
            // 
            this.miTraceClear.Index = 10;
            this.miTraceClear.Text = "&Clear";
            this.miTraceClear.Click += new System.EventHandler(this.miTraceClear_Click);
            // 
            // basicIdeObj1
            // 
            this.basicIdeObj1.BackColor = System.Drawing.SystemColors.Window;
            this.basicIdeObj1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.basicIdeObj1.SelBackColor = System.Drawing.SystemColors.Highlight;
            this.basicIdeObj1.SelForeColor = System.Drawing.SystemColors.HighlightText;
            this.basicIdeObj1.DebugTrace += new System.EventHandler<WinWrap.Basic.Classic.TextEventArgs>(this.basicIdeObj1_DebugTrace);
            this.basicIdeObj1.Disconnecting += new System.EventHandler<System.EventArgs>(this.basicIdeObj1_Disconnecting);
            this.basicIdeObj1.Synchronizing += new System.EventHandler<WinWrap.Basic.Classic.SynchronizingEventArgs>(this.basicIdeObj1_Synchronizing);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 144);
            this.Controls.Add(this.txtTrace);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "C# BasicIdeObj (on a form) - Debugger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

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

		private void Configure()
		{
			ConfigForm configform = new ConfigForm(this);
			configform.ShowDialog(this);
			if (m_conn == null)
				Close();
			else
				basicIdeObj1.Synchronized = true;
		}

		public bool Initialize(string ipAddress, int port)
		{
			Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				IPAddress ip = IPAddress.Parse(ipAddress);
				IPEndPoint ep = new IPEndPoint(ip, port);
				socket.Connect(ep);
				m_conn = new Connection(socket, new ReceivedDataDelegate(ReceivedDataAsync));
				return true;
			}
			catch (Exception ex)
			{
				socket.Close();
				MessageBox.Show(this, ex.Message);
			}

			return false;
		}

		public void ReceivedData(Connection conn, string data)
		{
			basicIdeObj1.Synchronize(data, 0); // id is ignored
		}

		public void ReceivedDataAsync(Connection conn, string data)
		{
			BeginInvoke(new ReceivedDataDelegate(ReceivedData), new object[]{conn, data});
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
            basicIdeObj1.AddExtension("$Feature WWB-COM True", null);

            // *** AddBasic: required
            // set your Application/Server certificate's secret first
            basicIdeObj1.Initialize();
            // ***

            // *** AddBasic: optional
			// turn on tracing
			basicIdeObj1.Trace(TraceConstants.All&~TraceConstants.QueryEvent);
			// ***

            // *** Remote: required
            basicIdeObj1.CreateOverlappedWindow();
            // ***

			// *** AddBasic: optional
			// load the file's most recently used file list from the registry
			string[] files = basicIdeObj1.FileMRU;
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\Remote\Debugger2"))
            {
                for (int i = 0; i < files.Length; ++i)
                    files[i] = (string)rk.GetValue("FileMRU" + (i + 1));

                object left = rk.GetValue("Left");
                object top = rk.GetValue("Top");
                object width = rk.GetValue("Width");
                object height = rk.GetValue("Height");
                if (left != null)
                    Left = (int)left;
                if (top != null)
                    Top = (int)top;
                if (width != null)
                    Width = (int)width;
                if (height != null)
                    Height = (int)height;
            }

			basicIdeObj1.FileMRU = files;
			// ***

			// *** AddBasic: optional
			basicIdeObj1.FileDir = Application.ExecutablePath + @"\..\..\..";
			// ***

			BeginInvoke(new MethodInvoker(Configure));
		}

		private void basicIdeObj1_DebugTrace(object sender, WinWrap.Basic.Classic.TextEventArgs e)
		{
			// *** AddBasic: not recommended (users are not interested in seeing this)
			// append the trace line to the trace output shown on the form
			if (txtTrace.TextLength > 30000)
				txtTrace.Text = "";

			txtTrace.SelectionStart = txtTrace.TextLength+1;
			if (txtTrace.TextLength > 0)
				txtTrace.SelectedText = "\r\n";

			txtTrace.SelectedText = e.Text;
			// ***
		}

		private void basicIdeObj1_Disconnecting(object sender, System.EventArgs e)
		{
			// *** AddBasic: optional
			// save the file menu's most recently used file list in the registry
			string[] files = basicIdeObj1.FileMRU;
            using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\Remote\Debugger2"))
            {
                for (int i = 0; i < files.Length; ++i)
                    rk.SetValue("FileMRU" + (i + 1), files[i]);

                rk.SetValue("Left", Left);
                rk.SetValue("Top", Top);
                rk.SetValue("Width", Width);
                rk.SetValue("Height", Height);
            }
			// ***
		}

		#region AddBasic: test

		private void miTraceToggle_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			MenuItem mi = sender as MenuItem;
			mi.Checked = !mi.Checked;
			int categories = 0;
			for (int i = 0; i < 6; ++i)
				if (miTrace.MenuItems[i].Checked)
					categories |= (i < 4 ? 1 : 4) << i;

			basicIdeObj1.Trace((TraceConstants)categories);
			// ***
		}

		private void miTraceNone_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			for (int i = 0; i < 6; ++i)
				miTrace.MenuItems[i].Checked = false;

			basicIdeObj1.Trace(TraceConstants.None);
			// ***
		}

		private void miTraceAll_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			for (int i = 0; i < 6; ++i)
				miTrace.MenuItems[i].Checked = true;

			basicIdeObj1.Trace(TraceConstants.All);
			// ***
		}

		private void miTraceClear_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			txtTrace.Text = "";
			// ***
		}

		#endregion

		private void basicIdeObj1_Synchronizing(object sender, WinWrap.Basic.Classic.SynchronizingEventArgs e)
		{
			m_conn.Send(e.Param);
		}
	}
}
