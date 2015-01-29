using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32;
using WinWrap.Basic;
using WinWrap.Basic.Classic;

namespace samp
{
	/// <summary>
	/// Summary description for BasicForm.
	/// </summary>
	public class BasicForm : System.Windows.Forms.Form, IBasicThread
	{
		private WinWrap.Basic.BasicIdeCtl basicIdeCtl1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.ComponentModel.IContainer components;

		// *** Thread: required
		private IBasicThreadCollection basicthreadcollection_;
		// ***

		public BasicForm(IBasicThreadCollection basicthreadcollection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			// *** Threads: required
			basicthreadcollection_ = basicthreadcollection;
			// ***
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.SuspendLayout();
			// 
			// basicIdeCtl1
			// 
			this.basicIdeCtl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.basicIdeCtl1.BackColor = System.Drawing.Color.White;
			this.basicIdeCtl1.DefaultObjectName = "Object.obm|Object";
			this.basicIdeCtl1.ForeColor = System.Drawing.Color.Black;
			this.basicIdeCtl1.Location = new System.Drawing.Point(0, 0);
			this.basicIdeCtl1.Name = "basicIdeCtl1";
            this.basicIdeCtl1.SelBackColor = System.Drawing.Color.Aqua;
			this.basicIdeCtl1.SelForeColor = System.Drawing.Color.White;
			this.basicIdeCtl1.Size = new System.Drawing.Size(560, 338);
			this.basicIdeCtl1.TabIndex = 0;
			this.basicIdeCtl1.Disconnecting += new System.EventHandler<System.EventArgs>(this.basicIdeCtl1_Disconnecting);
			// 
			// BasicForm
			// 
			this.ClientSize = new System.Drawing.Size(560, 337);
			this.Controls.Add(this.basicIdeCtl1);
			this.Menu = this.mainMenu1;
			this.Name = "BasicForm";
			this.Text = "C# BasicIdeCtl - Threads";
			this.Load += new System.EventHandler(this.BasicForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		// *** Threads: example
		// Implement the Spawn and ShowIDE WinWrap Basic language instructions
		[ClassInterface(ClassInterfaceType.AutoDual)]
		public class BasicObject
		{
			private BasicForm form1_;

			internal BasicObject(BasicForm form1)
			{
				form1_ = form1;
			}

			public void ShowIDE()
			{
				form1_.ShowIDE();
			}

			public void Spawn(string FileName)
			{
				form1_.Spawn(FileName);
			}
		}
		// ***

		internal void ShowIDE()
		{
			// *** Thread: test
			// Help implement the ShowIDE WinWrap Basic instruction
			this.Activate();
			// ***
		}

		internal void Spawn(string FileName)
		{
			// *** Thread: test
			// Help implement the Spawn WinWrap Basic instruction
			Spawn(basicthreadcollection_, FileName);
			// ***
		}

		// *** Threads: example
		private AutoResetEvent started_ = new AutoResetEvent(false);
		// ***

		public static void Spawn(IBasicThreadCollection basicthreadcollection, string FileName)
		{
			// *** Threads: example
			// Create a new BasicForm (contains a BasicIdeCtl control)
			BasicForm form1 = new BasicForm(basicthreadcollection);
			// Attach the new form to the collection and use it's IBasicThread implementation
			form1.basicIdeCtl1.AttachBasicThread(form1);
			// Create a new thread
			Thread thread = new Thread(new ThreadStart(form1.ThreadProc));
			// Must be a single threaded apartment
			thread.SetApartmentState(ApartmentState.STA);
			// Start the thread
			thread.Start();
			// Run the script in the new thread
			form1.Spawn_(FileName);
			// ***
		}

		// *** Threads: example
		private delegate bool Spawn1Delegate(string FileName);
		private delegate void Spawn2Delegate();
		// ***

		internal void Spawn_(string FileName)
		{
			// *** Threads: example
			// Allow a new BasicForm to be created without running a script
			if (FileName == null)
				return;

			// Wait for the new thread to start
			if (!started_.WaitOne(10000, false))
				throw new Exception("Spawn failed.");

			// Invoke Spawn1 in the new thread
			Delegate d1 = Delegate.CreateDelegate(typeof(Spawn1Delegate), this, "Spawn1");
			if (!(bool)Invoke(d1, new object[]{FileName}))
				throw new Exception("Spawn failed.");

			// Start Spawn2 in the new thread
			Delegate d2 = Delegate.CreateDelegate(typeof(Spawn2Delegate), this, "Spawn2");
			BeginInvoke(d2, null);
			// ***
		}

		private bool Spawn1(string StartFileName)
		{
			// *** Threads: example
			// Set the current file name so that Spawn2 can start the script
			string OldFileName = basicIdeCtl1.FileName;
			basicIdeCtl1.FileName = StartFileName;
			// Return true if the script exists
			return basicIdeCtl1.FileName != OldFileName;
			// ***
		}

		private void Spawn2()
		{
			// *** Threads: example
			// Start the script execution
			basicIdeCtl1.Run = true;
			// ***
		}

		private void ThreadProc()
		{
			// *** Threads: required
			// Add this IBasicThread object to the collection
			basicthreadcollection_.AddBasicThread(this);
			// Run this form's message loop
			Application.Run(this);
			// Remove this IBasicThread object from the collection
			basicthreadcollection_.RemoveBasicThread(this);
			// ***
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			// *** Thread: example
			// Signal that the form's thread is ready
			started_.Set();
			// ***
			base.OnHandleCreated (e);
		}

		private void BasicForm_Load(object sender, System.EventArgs e)
		{
            basicIdeCtl1.AddExtension("$Feature WWB-COM True", null);

            // *** AddBasic: optional
			// turn on tracing
			basicIdeCtl1.Trace(TraceConstants.All&~TraceConstants.QueryEvent);
			// ***

			// *** Threads: example
			// Add Spawn and ShowIDE instructions to WinWrap Basic language
			basicIdeCtl1.AddExtension("-", new BasicObject(this));
			// ***

			// *** AddBasic: optional
			string[] files = basicIdeCtl1.FileMRU;
			using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\IdeCtl\Threads"))
				for (int i = 0; i < files.Length; ++i)
					files[i] = (string)rk.GetValue("FileMRU" + (i + 1));

			basicIdeCtl1.FileMRU = files;
			// ***

			// *** AddBasic: optional
			basicIdeCtl1.FileDir = Application.ExecutablePath + @"\..\..\..";
			// ***
		}

		private void basicIdeCtl1_Disconnecting(object sender, System.EventArgs e)
		{
			// *** AddBasic: optional
			string[] files = basicIdeCtl1.FileMRU;
			using (RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Polar Engineering\C#\IdeCtl\Threads"))
				for (int i = 0; i < files.Length; ++i)
					rk.SetValue("FileMRU" + (i + 1), files[i]);
			// ***
		}

		// *** Threads: required
		// Implement IBasicThread so this form's thread can be killed
		#region IBasicThread Members

		public IBasicThreadCollection BasicThreadCollection
		{
			get
			{
				lock (this)
					return basicthreadcollection_;
			}
		}

		private bool inkill_;

		public bool InKill
		{
			get
			{
				lock (this)
					return inkill_;
			}
		}

		public bool IsAlive
		{
			get
			{
				lock (this)
					return IsHandleCreated;
			}
		}

		private delegate void CloseDelegate();

		public bool Kill()
		{
			if (!IsAlive)
				return true;

			if (!InvokeRequired)
			{
				Close();
				return true;
			}

			lock (this)
			{
				if (inkill_)
					return true;

				inkill_ = true;
			}

			Delegate d = Delegate.CreateDelegate(typeof(CloseDelegate), this, "Close");
			Invoke(d, null);

			lock (this)
				inkill_ = false;

			return !IsAlive;
		}

		#endregion
		// ***
	}
}
