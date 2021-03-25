using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using Ladeskab.Interfaces;
using NSubstitute;

namespace LogFileTester.Test
{
    [TestFixture]
    public class TestLogFile
    {
        private LogFile _uut;
        private ITimeProvider _tProvider;
        private IFileWriter _fWriter;
        [SetUp]
        public void Setup()
        {
            _tProvider = Substitute.For<ITimeProvider>();
            _fWriter = Substitute.For<IFileWriter>();
            _uut = new LogFile(_fWriter, _tProvider);
        }

        [TestCase(1)]
        [TestCase(4)]
        public void Logging_DoorUnlocked_CorrectDate(int id)
        {
            DateTime date = new DateTime(2021, 03, 25,15,25,13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorUnlocked(id);
            string resultString = "Date: " + date + " - Døren er låst op med ID: " + id;
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains(date.ToString())));

        }

        [TestCase(3)]
        [TestCase(5)]
        public void Logging_DoorUnlocked_CorrectId(int id)
        {
            DateTime date = new DateTime(2021, 03, 25, 15, 25, 13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorUnlocked(id);
            string resultString = "Date: " + date + " - Døren er låst op med ID: " + id;
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains(id.ToString())));

        }


        [TestCase(43)]
        [TestCase(22)]
        public void Logging_DoorLocked_CorrectDate(int id)
        {
            DateTime date = new DateTime(2021, 03, 25, 15, 25, 13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorUnlocked(id);
            string resultString = "Date: " + date + " - Døren er blevet lukket med ID: " + id;
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains(date.ToString())));

        }

        [TestCase(43)]
        [TestCase(333)]
        public void Logging_DoorLocked_CorrectId(int id)
        {
            DateTime date = new DateTime(2021, 03, 25, 15, 25, 13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorUnlocked(id);
            string resultString = "Date: " + date + " - Døren er blevet lukket med ID: " + id;
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains(id.ToString())));

        }
    }
}
