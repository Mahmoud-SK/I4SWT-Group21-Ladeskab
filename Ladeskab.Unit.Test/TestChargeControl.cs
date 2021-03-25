using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Ladeskab;
using Ladeskab.Interfaces;

namespace chargeCtrl.Test
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IUsbCharger _usbCharger;
        private IDisplay _display;
        [SetUp]
        public void Setup()
        {
            //_usbCharger Substitute.
            //_uut = new ChargeControl();
        }
    }
}
