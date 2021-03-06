using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using Ladeskab.Interfaces;
using NUnit.Framework;

namespace door.Test
{
    [TestFixture]
    class TestDoor
    {
        private Door _uut;
        private DoorStateEventArgs _DoorStateEventArgs;


        [SetUp]
        public void SetUp()
        {
            _uut = new Door();
            _DoorStateEventArgs = new DoorStateEventArgs();
            _uut.DoorStateEvent += (o,args) =>
            {
                _DoorStateEventArgs = args;
            };
        }


        [Test]
        public void ctor_DoorLockIsFalse()
        {
            Assert.That(_uut.DoorLock, Is.EqualTo(false));
        }


        [Test]
        public void LockDoor_DoorLockIsTrue()
        {
            _uut.UnlockDoor();
            _uut.LockDoor();
            Assert.That(_uut.DoorLock, Is.EqualTo(true));
        }


        [Test]
        public void UnlockDoor_DoorLockIsFalse()
        {
            _uut.LockDoor();
            _uut.UnlockDoor();
            Assert.That(_uut.DoorLock, Is.EqualTo(false));
        }


        [Test]
        public void OnDoorOpen_EventIsTrue()
        {
            _uut.OnDoorClose();
            _uut.OnDoorOpen();
            Assert.That(_DoorStateEventArgs.DoorOpen, Is.EqualTo(true));
        }



        [Test]
        public void OnDoorOpen_EventIsFalse()
        {
            _uut.OnDoorOpen();
            _uut.OnDoorClose();
            Assert.That(_DoorStateEventArgs.DoorOpen, Is.EqualTo(false));
        }

        [Test]
        public void OnDoorClose_EventIsTrue()
        {
            _uut.OnDoorClose();
            _uut.OnDoorOpen();
            Assert.That(_DoorStateEventArgs.DoorOpen, Is.EqualTo(true));
        }

        [Test]
        public void OnDoorClose_EventIsFalse()
        {
            _uut.OnDoorOpen();
            _uut.OnDoorClose();
            Assert.That(_DoorStateEventArgs.DoorOpen, Is.EqualTo(false));
        }
    }
}
