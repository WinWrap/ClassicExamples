using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
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
		// *** AddExt: example
		private AppObject appobject = new AppObject();
		// ***
		private WinWrap.Basic.BasicIdeCtl basicIdeCtl1;
		private System.Windows.Forms.TextBox txtTrace;
		private System.Windows.Forms.Splitter splitter1;
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
			this.basicIdeCtl1 = new WinWrap.Basic.BasicIdeCtl();
			this.txtTrace = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
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
			this.SuspendLayout();
			// 
			// basicIdeCtl1
			// 
			this.basicIdeCtl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.basicIdeCtl1.BackColor = System.Drawing.Color.White;
			this.basicIdeCtl1.ForeColor = System.Drawing.Color.Black;
			this.basicIdeCtl1.HighlightExtension = System.Drawing.Color.DarkBlue;
			this.basicIdeCtl1.HighlightReserved = System.Drawing.Color.Blue;
			this.basicIdeCtl1.Location = new System.Drawing.Point(0, 0);
			this.basicIdeCtl1.Name = "basicIdeCtl1";
            this.basicIdeCtl1.SelBackColor = System.Drawing.Color.Aqua;
			this.basicIdeCtl1.SelForeColor = System.Drawing.Color.Black;
			this.basicIdeCtl1.Size = new System.Drawing.Size(560, 342);
			this.basicIdeCtl1.TabIndex = 5;
			this.basicIdeCtl1.Disconnecting += new System.EventHandler<System.EventArgs>(this.basicIdeCtl1_Disconnecting);
			this.basicIdeCtl1.DebugTrace += new System.EventHandler<WinWrap.Basic.Classic.TextEventArgs>(this.basicIdeCtl1_DebugTrace);
			// 
			// txtTrace
			// 
			this.txtTrace.BackColor = System.Drawing.Color.Black;
			this.txtTrace.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtTrace.ForeColor = System.Drawing.Color.Lime;
			this.txtTrace.Location = new System.Drawing.Point(0, 350);
			this.txtTrace.Multiline = true;
			this.txtTrace.Name = "txtTrace";
			this.txtTrace.ReadOnly = true;
			this.txtTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtTrace.Size = new System.Drawing.Size(560, 144);
			this.txtTrace.TabIndex = 1;
			this.txtTrace.Text = "";
			this.txtTrace.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 342);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(560, 8);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
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
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(560, 494);
			this.Controls.Add(this.basicIdeCtl1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.txtTrace);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "C# BasicIdeCtl - AddExt";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			// *** AddBasic: optional
			// turn on tracing
			basicIdeCtl1.Trace(TraceConstants.All&~TraceConstants.QueryEvent);
			// ***

			// *** AddExt: example
			basicIdeCtl1.AddExtension(".AppObject.", appobject);
			// ***

			// *** AddBasic: optional
			// load the file's most recently used file list from the registry
			string[] files = basicIdeCtl1.FileMRU;
			using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\IdeCtl\AddExt"))
				for (int i = 0; i < files.Length; ++i)
					files[i] = (string)rk.GetValue("FileMRU" + (i + 1));

			basicIdeCtl1.FileMRU = files;
			// ***

			// *** AddBasic: optional
			basicIdeCtl1.FileDir = Application.ExecutablePath + @"\..\..\..";
			// ***
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			basicIdeCtl1.Height = splitter1.Top;
		}

		private void basicIdeCtl1_DebugTrace(object sender, WinWrap.Basic.Classic.TextEventArgs e)
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

		private void basicIdeCtl1_Disconnecting(object sender, System.EventArgs e)
		{
			// *** AddBasic: optional
			// save the file menu's most recently used file list in the registry
			string[] files = basicIdeCtl1.FileMRU;
			using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\IdeCtl\AddExt"))
				for (int i = 0; i < files.Length; ++i)
					rk.SetValue("FileMRU" + (i + 1), files[i]);
			// ***
		}

		#region AddBasic: test

		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			basicIdeCtl1.Height = splitter1.Top;
		}

		private void miTraceToggle_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			MenuItem mi = sender as MenuItem;
			mi.Checked = !mi.Checked;
			int categories = 0;
			for (int i = 0; i < 6; ++i)
				if (miTrace.MenuItems[i].Checked)
					categories |= (i < 4 ? 1 : 4) << i;

			basicIdeCtl1.Trace((TraceConstants)categories);
			// ***
		}

		private void miTraceNone_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			for (int i = 0; i < 6; ++i)
				miTrace.MenuItems[i].Checked = false;

			basicIdeCtl1.Trace(TraceConstants.None);
			// ***
		}

		private void miTraceAll_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			for (int i = 0; i < 6; ++i)
				miTrace.MenuItems[i].Checked = true;

			basicIdeCtl1.Trace(TraceConstants.All);
			// ***
		}

		private void miTraceClear_Click(object sender, System.EventArgs e)
		{
			// *** AddBasic: test
			txtTrace.Text = "";
			// ***
		}

		#endregion
	}
}
