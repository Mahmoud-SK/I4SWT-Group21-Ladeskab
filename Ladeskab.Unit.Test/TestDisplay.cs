using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using Ladeskab.Interfaces;
using NSubstitute;

namespace display.Test
{
    [TestFixture]
    public class TestDisplay
    {
        private Display _uut;
        private IConsoleWriter _consoleWriter;
        [SetUp]
        public void Setup()
        {
            _consoleWriter = Substitute.For<IConsoleWriter>();
            _uut = new Display(_consoleWriter);
        }

        [Test]
        public void ShowInstruction_ShowNewInstruction()
        {
            _uut.ShowInstruction("newInstruction");
            _consoleWriter.Received(1).WriteToConsole("newInstruction");
        }

        [Test]
        public void ShowStatus_ShowNewStatus()
        {
            _uut.ShowStatus("newStatus");
            _consoleWriter.Received(1).WriteToConsole("newStatus");
        }

        [Test]
        public void ShowStatusAndShowInstruction_ShowNewInstructionAndStatus_ShowInstructionIsNotEffektedByShowStatus()
        {
            _uut.ShowInstruction("newInstruction");
            _uut.ShowStatus("newStatus");
            _consoleWriter.Received(2).WriteToConsole("newInstruction");
        }

        [Test]
        public void ShowStatusAndShowInstruction_ShowNewInstructionAndStatus_ShowStatusIsNotEffektedByShowInstruction()
        {
            _uut.ShowStatus("newStatus");
            _uut.ShowInstruction("newInstruction");
            _consoleWriter.Received(2).WriteToConsole("newStatus");
        }
    }
}
