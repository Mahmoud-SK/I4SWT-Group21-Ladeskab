using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using Ladeskab.Interfaces;

namespace LogFileTester.Test
{
    [TestFixture]
    public class TestLogFile
    {
        private LogFile _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new LogFile();
        }

        [TestCase(1)]
        public void Logging_DoorUnlocked(int id)
        {
            _uut.LogDoorUnlocked(id);
            
        }

        [Test]
        public void Logging_DoorLocked(int id)
        {
            
        }
    }
}
