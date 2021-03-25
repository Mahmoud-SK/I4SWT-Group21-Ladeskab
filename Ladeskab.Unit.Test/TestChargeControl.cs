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
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_display, _usbCharger);
        }

        [Test]
        public void Connected_IsConnected_ReturnTrue()
        {
            _usbCharger.Connected.Returns(true);
            Assert.That(_uut.Connected(), Is.True);
        }

        [Test]
        public void Connected_IsNotConnected_ReturnFalse()
        {
            _usbCharger.Connected.Returns(false);
            Assert.That(_uut.Connected(), Is.False);
        }

        [Test]
        public void StartCharge_ChargeStarted()
        {
            _uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
        }

        [Test]
        public void StopCharge_ChargeStopped()
        {
            _uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        [TestCase(0)]
        public void NewCurrent_ZeroCurrent_NothingDisplayed(int _current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = _current });
            _display.Received(0).Show(Arg.Any<string>());
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void NewCurrent_FullyCharged_DisplayFullyCharged(int _current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs {Current = _current});
            _display.Received(1).Show(Arg.Is<string>(x => x.Contains("Telefonen er fuldt opladet")));
        }

        [TestCase(6)]
        [TestCase(350)]
        [TestCase(500)]
        public void NewCurrent_Charging_DisplayCharging(int _current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = _current });
            _display.Received(1).Show(Arg.Is<string>(x => x.Contains("Opladning er igang")));
        }

        [TestCase(501)]
        public void NewCurrent_FailurHighCurrent_DisplayError(int _current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = _current });
            _display.Received(1).Show(Arg.Is<string>(x => x.Contains("Fejl i opladning")));
        }

        [TestCase(501)]
        public void NewCurrent_FailurHighCurrent_ChargeStopped(int _current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs { Current = _current });
            _usbCharger.Received(1).StopCharge();
        }
    }
}
