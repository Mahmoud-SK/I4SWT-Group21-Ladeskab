using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
	public class RfidEventArgs : EventArgs
	{
	}		
	
	public interface IRfidReader
	{
		// Eventhandler
		event EventHandler<RfidEventArgs> RfidDetectedEvent;

		//Reading Rfid
		void onRfidRead(int id);
	}
}
