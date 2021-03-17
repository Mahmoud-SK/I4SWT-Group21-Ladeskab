using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class ChargeControl : IChargeControl
    {
        private bool _connected;
        private IDisplay _display;
        private IUsbCharger _usbCharger;

        public ChargeControl(IDisplay display, IUsbCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
        }

        public bool IsConnected()
        {
            return _connected;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }
	}
}
