using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
	public class ChargeControl : IChargeControl
    {
        private IDisplay _display;
        private IUsbCharger _usbCharger;

        public ChargeControl(IDisplay display, IUsbCharger usbCharger)
        {
            _display = display;
            _usbCharger = usbCharger;
            usbCharger.CurrentValueEvent += newCurrent;
        }

        public bool Connected()
        {
            return _usbCharger.Connected;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        public void newCurrent(object sender, CurrentEventArgs e)
        {
            if (e.Current > 0 && e.Current <= 5)
                _display.Show("Telefonen er fuldt opladet");
            else if (e.Current > 5 && e.Current <= 500)
                _display.Show("Opladning er igang");
            else if (e.Current > 500)
            {
                _usbCharger.StopCharge();
                _display.Show("Fejl i opladning");
            }
        }

	}
}
