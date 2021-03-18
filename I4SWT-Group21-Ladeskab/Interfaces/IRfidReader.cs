using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
	public class RfidReaderEventArgs : EventArgs
	{
	}		
	
	public interface IRfidReader
	{
		// Eventhandler
		event EventHandler<RfidEventArgs> RfidDetectedEvent;
		
		// Property for detecting Rfid tag
		int RfidDetected { get; }
	}
}
