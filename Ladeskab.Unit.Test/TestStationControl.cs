using Ladeskab;
using Ladeskab.Interfaces;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace stationControl.Test
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

        #region RfidDetected()
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
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fLogFile.Received(1).LogDoorLocked(17);
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_DisplayInstructionMessage()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.")));
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliable_DisplayElseMessage()
        {
            _fChargeControl.Connected().Returns(false);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Din telefon er ikke ordentlig tilsluttet. Prøv igen.")));
        }

        [Test]
        public void RfidDetected_NewRfidDetectedLocked_DoorIsUnlocked()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });

            _fDoor.Received(1).UnlockDoor();

        }

        [Test]
        public void RfidDetected_NewRfidDetectedLocked_StopCharging()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 12 });

            _fChargeControl.Received(1).StopCharge();
        }

        [Test]
        public void RfidDetected_NewRfidDetectedLocked_LogDoorUnlocked()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fLogFile.Received(1).LogDoorUnlocked(17);
        }

        [Test]
        public void RfidDetected_NewRfidDetectedLocked_DisplayInstructionMessage()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Tag din telefon ud af skabet og luk døren")));
        }

        [Test]
        public void RfidDetected_NewRfidDetectedAvaliableLocked_DisplayElseMessage()
        {
            _fChargeControl.Connected().Returns(true);

            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 17 });
            _fRfidReader.RfidDetectedEvent += Raise.EventWith(new RfidEventArgs { Id = 15 });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Forkert RFID tag")));
        }
        #endregion

        #region DoorEventHandler()

        [Test]
        public void DoorEventHandler_NewDoorEventAvaliable_DisplayInstructionMessage()
		{

            _fDoor.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorOpen = true });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Tilslut Telefon")));
        }

        [Test]
        public void DoorEventHandler_NewDoorEventDoorOpen_DisplayInstructionMessage()
        {
           

            _fDoor.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorOpen = true });
            _fDoor.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorOpen = false });

            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Indlæs RFID")));
        }

        [Test]
        public void DoorEventHandler_NewDoorEventDoorOpen_DisplayElseMessage()
        {
            
            _fDoor.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorOpen = true });
            _fDoor.DoorStateEvent += Raise.EventWith(new DoorStateEventArgs { DoorOpen = true });


            _fDisplay.Received(1).ShowInstruction(Arg.Is<string>(x => x.Contains("Luk døren")));
        }

        #endregion

    }
}
