using System;
using System.Runtime.InteropServices;

namespace samp
{
	/// <summary>
	/// Summary description for AppObject.
	/// </summary>

	// *** AddEvent: example
	[InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
	public interface _AppObjectEvents
	{
		void ValueChanged();
	}

	[ClassInterface(ClassInterfaceType.AutoDual),
	ComSourceInterfaces(typeof(_AppObjectEvents))]
	public class AppObject
	{
		private string value_;

		internal delegate void ValueChangedEventHandler();
		internal event ValueChangedEventHandler ValueChanged;

		internal AppObject()
		{
		}

		[DispId(0)]
		public string Value
		{
			get { return value_; }
			set {
				value_ = value;
                try
                {
                    ValueChanged();
                }
                catch
                {
                }
			}
		}
	}
	// ***
}
