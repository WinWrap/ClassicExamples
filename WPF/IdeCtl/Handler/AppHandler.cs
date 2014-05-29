using System;
using System.Runtime.InteropServices;
using WinWrap.Basic;

namespace samp
{
	/// <summary>
	/// Summary description for AppHandler.
	/// </summary>

	// *** Handler: example
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
	public class AppHandler : IDisposable
	{
		private Handler handler_;
		private string value_;

		internal AppHandler(Handler handler)
		{
			handler_ = handler;
		}

		[DispId(0)]
		public string Value
		{
			get { return value_; }
			set {
				value_ = value;
                if (handler_ != null && handler_.Exists)
				{
					try
					{
						handler_.Call();
					}
					catch (TerminatedException)
					{
						// script execution has been terminated
					}
					catch (Exception e)
					{
						handler_.ReportError(e);
					}
				}
			}
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (handler_ != null)
			{
				handler_.Dispose();
				handler_ = null;
			}
		}

		#endregion
	}
	// ***
}
