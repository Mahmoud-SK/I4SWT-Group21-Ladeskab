using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class RfidReader : IRfidReader
	{
		public event EventHandler<RfidEventArgs> RfidDetectedEvent;

		public int RfidDetected { get; }
	}
}
