using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
	public class RfidEventArgs : EventArgs
	{
		public int Id { get; set; }
	}		
	
	public interface IRfidReader
	{
		// Eventhandler
		event EventHandler<RfidEventArgs> RfidDetectedEvent;
	}
}
