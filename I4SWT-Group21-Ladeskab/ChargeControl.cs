using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class ChargeControl : IChargeControl
    {
        private bool connected;
        private IDisplay display;

        public bool isConnected()
        {
            return connected;
        }

        public void startCharge()
        {

        }

        public void stopCharge()
        {

        }
	}
}
