using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class RfidReader : IRfidReader
	{
		public event EventHandler<RfidEventArgs> RfidDetectedEvent;
		public void onRfidRead(int id)
		{
			RfidDetectedEvent?.Invoke(this, new RfidEventArgs() { = this.id});
		}
	}

}
