using System;
using System.Runtime.InteropServices;

namespace samp
{
	/// <summary>
	/// Summary description for AppObject.
	/// </summary>

	// *** AddExt: example
	[ComVisible(true), ClassInterface(ClassInterfaceType.AutoDual)]
	public class AppObject
	{
		private string value_;

		internal AppObject()
		{
		}

		[DispId(0)]
		public string Value
		{
			get { return value_; }
			set { value_ = value; }
		}
	}
	// ***
}
