using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class TestStationControl
    {
        private StationControl _uut;
        private IChargeControl _fChargeControl;
        private IDoor _fDoor;
        private IDisplay _fDisplay;
        private ILogFile _fLogFile;
        private IRfidReader _fRfidReader;

        [SetUp]
        public void Setup()
        {
            _fChargeControl = Substitute.For<IChargeControl>();
            _fDoor = Substitute.For<IDoor>();
            _fDisplay = Substitute.For<IDisplay>();
            _fLogFile = Substitute.For<ILogFile>();
            _fRfidReader = Substitute.For<IRfidReader>();

            _uut = new StationControl(_fChargeControl, _fDoor, _fRfidReader, _fDisplay, _fLogFile);

        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_DoorIsLocked()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });
            
            _fDoor.Received(1).LockDoor();

        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_StartCharging()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });

            _fChargeControl.Received(1).StartCharge();
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_LogDoorLocked()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fLogFile.Received(1).LogDoorLocked(17);
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_DisplayShow()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fDisplay.Received(1).Show("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliableElse_ReturnsElseMessage()
        {
            _fChargeControl.Connected().Returns(false);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            //_fDoor.Received(0).LockDoor();
            _fDisplay.Received(1).Show("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
        }


    }
}
