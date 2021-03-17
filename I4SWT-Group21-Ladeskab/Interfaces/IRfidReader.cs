using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
	public class CurrentEventArgs : EventArgs
	{
	}		
	
	public interface IRfidReader
	{
		// Eventhandler
		event EventHandler<CurrentEventArgs> RfidDetectedEvent;
		
		// Property for detecting Rfid tag
		int RfidDetected { get; }
	}
}
