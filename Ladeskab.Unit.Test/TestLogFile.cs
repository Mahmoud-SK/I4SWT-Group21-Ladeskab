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


        [TestCase(3)]
        [TestCase(5)]
        public void Logging_DoorUnlocked_CorrectIdAndDate(int id)
        {
            DateTime date = new DateTime(2021, 03, 25, 15, 25, 13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorUnlocked(id);
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains("Date: " + date + " - Døren er låst op med ID: " + id)));

        }

        [TestCase(43)]
        [TestCase(22)]
        public void Logging_DoorLocked_CorrectIdAndDate(int id)
        {
            DateTime date = new DateTime(2021, 03, 25, 15, 25, 13);
            _tProvider.ProvideDate().Returns(date);
            _uut.LogDoorLocked(id);
            _fWriter.Received(1).WriteToFile(Arg.Is<string>(x => x.Contains("Date: " + date + " - Døren er blevet lukket med ID: " + id)));

        }

    }
}
