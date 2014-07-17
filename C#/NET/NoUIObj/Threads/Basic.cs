using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading;
using System.Windows.Forms;
using WinWrap.Basic;
using WinWrap.Basic.Classic;

namespace samp
{
	/// <summary>
	/// Summary description for Basic.
	/// </summary>

	[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
	public class Basic : BasicNoUIObj
	{
		// *** Threads: example
		// Implement the Spawn and ShowIDE WinWrap Basic language instructions
		[ClassInterface(ClassInterfaceType.AutoDual)]
		public class BasicObject
		{
			private Basic basic_;

			internal BasicObject(Basic basic)
			{
				basic_ = basic;
			}

			public void Spawn(string FileName)
			{
				basic_.Spawn(FileName);
			}
		}
		// ***

		// *** Thread: test
		Form form_;
		// ***

		public Basic(Form form)
		{
			// *** Thread: test
			form_ = form;
			// ***
		}

		internal void Spawn(string FileName)
		{
			// *** Thread: test
			// Help implement the Spawn WinWrap Basic instruction
			Spawn(form_, GetBasicThread().BasicThreadCollection, FileName);
			// ***
		}

		public static void Spawn(Form form, IBasicThreadCollection basicthreadcollection, string FileName)
		{
			// *** Threads: example
			// Create a new Basic (BasicNoUIObj) object
			Basic basic = new Basic(form);
			// Begin a new Basic thread and run the script in the new thread
			basic.Spawn_(basicthreadcollection, FileName);
			// ***
		}

		// *** Threads: example
		private delegate bool Spawn1Delegate(string FileName);
		private delegate void Spawn2Delegate();
		// ***

		internal void Spawn_(IBasicThreadCollection basicthreadcollection, string FileName)
		{
			// *** Threads: example
			// Begin a new Basic thread and add it to the collection
			BeginBasicThread(basicthreadcollection);

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
			// *** AddBasic: required
			Initialize();
			// ***

			// *** AddBasic: optional
			// turn on tracing
			Trace(TraceConstants.All);
			// ***

			// *** AddBasic: recommended
			// manage the Basic object/control using this form
			AttachToForm(form_, ManageConstants.All);
			// ***

			// *** Threads: example
			// Add Spawn and ShowIDE instructions to WinWrap Basic language
			AddExtension("-", new BasicObject(this));
			// ***

			// *** Threads: example
			// Set the current file name so that Spawn2 can start the script
			string OldFileName = FileName;
			FileName = StartFileName;
			// Return true if the script exists
			return FileName != OldFileName;
			// ***
		}

		private void Spawn2()
		{
			// *** Threads: example
			// Start the script execution
			Run = true;
			// ***
		}
	}
}
