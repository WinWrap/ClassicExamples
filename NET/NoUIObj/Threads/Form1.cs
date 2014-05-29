using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using Microsoft.Win32;
using WinWrap.Basic;
using WinWrap.Basic.Classic;

namespace samp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtTrace;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem miFileExit;
		private System.Windows.Forms.MenuItem miFile;
		private System.Windows.Forms.MenuItem miFileRun;
		private System.Windows.Forms.MenuItem miFileSep1;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.miFile = new System.Windows.Forms.MenuItem();
			this.miFileRun = new System.Windows.Forms.MenuItem();
			this.miFileSep1 = new System.Windows.Forms.MenuItem();
			this.miFileExit = new System.Windows.Forms.MenuItem();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
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
			this.txtTrace.Size = new System.Drawing.Size(704, 219);
			this.txtTrace.TabIndex = 1;
			this.txtTrace.Text = "";
			this.txtTrace.WordWrap = false;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miFile});
			// 
			// miFile
			// 
			this.miFile.Index = 0;
			this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.miFileRun,
																				   this.miFileSep1,
																				   this.miFileExit});
			this.miFile.Text = "&File";
			// 
			// miFileRun
			// 
			this.miFileRun.Index = 0;
			this.miFileRun.Text = "&Run test1.bas";
			this.miFileRun.Click += new System.EventHandler(this.miFileRun_Click);
			// 
			// miFileSep1
			// 
			this.miFileSep1.Index = 1;
			this.miFileSep1.Text = "-";
			// 
			// miFileExit
			// 
			this.miFileExit.Index = 2;
			this.miFileExit.Text = "E&xit";
			this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(704, 225);
			this.Controls.Add(this.txtTrace);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "C# BasicNoUIObj (NOT on a form) - Threads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		// *** Threads: required
		private BasicThreadCollection basicthreadcollection_ = new BasicThreadCollection();
		// ***

		// *** Threads: optional
		private ArrayList tracedata_ = ArrayList.Synchronized(new ArrayList());
		// ***

		private void AddDebugTraceData()
		{
			// *** Threads: optional
			// This method executes in this form's thread
			// write the trace data the debug output
			int n = tracedata_.Count;
			if (n == 0)
				return;

			Array tracedata = Array.CreateInstance(typeof(string), n);
			tracedata_.CopyTo(0, tracedata, 0, n);
			tracedata_.RemoveRange(0, n);
			string s = string.Join("\r\n", (string[])tracedata);

			// don't add to txtTrace if the form has been destroyed
			if (!IsHandleCreated)
				return;

			// append the trace line to the trace output shown on the form
			if (txtTrace.TextLength > 30000)
				txtTrace.Text = "";

			txtTrace.SelectionStart = txtTrace.TextLength+1;
			if (txtTrace.TextLength > 0)
				txtTrace.SelectedText = "\r\n";

			txtTrace.SelectedText = s;
			// ***
		}

		private void basicthreadcollection_DebugTrace(object sender, TextEventArgs e)
		{
			// *** Threads: optional
			// This method executes in the IBasicThread's thread
			// add trace line to the debug output
			tracedata_.Add(e.Text);
			// ***
		}

		private void Form1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			// *** Threads: optional
			AddDebugTraceData();
			// ***
		}

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
		{
			// *** Threads: required
			// Kill all basic thread, cancel close if not successful
			e.Cancel = !basicthreadcollection_.KillAll();
			// ***
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// *** Threads: recommended
			basicthreadcollection_.DebugTrace += new System.EventHandler<WinWrap.Basic.Classic.TextEventArgs>(basicthreadcollection_DebugTrace);
			// ***
		}

		private void miFileRun_Click(object sender, System.EventArgs e)
		{
			// *** Threads: example
			try
			{
				Basic.Spawn(this, basicthreadcollection_, Application.ExecutablePath + "\\..\\..\\..\\" + "test1.bas");
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.ToString());
			}
			// ***
		}

		private void miFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			// *** Threads: optional
			AddDebugTraceData();
			// ***
		}
	}
}
