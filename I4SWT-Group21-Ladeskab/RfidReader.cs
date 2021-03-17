using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
	public class RfidReader : IRfidReader
	{
		public event EventHandler<CurrentEventArgs> RfidDetectedEvent;

		public int RfidDetected { get; }
	}
}
