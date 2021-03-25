using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using NUnit.Framework;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    class TestDoor
    {
        private Door _uut;

        [SetUp]
        public void SetUp()
        {
            _uut = new Door();
        }


        [Test]
        public void ctor_DoorLockIsFalse()
        {
            Assert.That(_uut.DoorLock, Is.EqualTo(false));
        }


        [Test]
        public void LockDoor_DoorLockIsTrue()
        {
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

    }
}
