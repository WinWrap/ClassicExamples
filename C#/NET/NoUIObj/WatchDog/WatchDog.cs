// *** WatchDog: sample
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Timers;
using WinWrap.Basic;
using WinWrap.Basic.Classic;

namespace samp
{
	/// <summary>
	/// Summary description for WatchDog.
	/// </summary>
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class WatchDog
	{
		private IBasicNoUI basic_;
		private Timer timer_;

		internal WatchDog(IBasicNoUI basic)
		{
			basic_ = basic;
			timer_ = new Timer();
			timer_.SynchronizingObject = basic as ISynchronizeInvoke;
			timer_.AutoReset = false;
			timer_.Elapsed += new ElapsedEventHandler(timer__Elapsed);
		}

		public void Start(double interval)
		{
			timer_.Interval = interval*1000;
			timer_.Enabled = true;
		}

		public void Stop()
		{
			timer_.Enabled = false;
		}

		private void timer__Elapsed(object sender, ElapsedEventArgs e)
		{
			if (basic_.Run)
				basic_.RunThis("Err.Raise 999,,\"Watchdog timer expired.\"");
		}
	}
}
// ***
