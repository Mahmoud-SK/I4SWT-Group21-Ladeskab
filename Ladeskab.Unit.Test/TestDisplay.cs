using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;
using Ladeskab.Interfaces;
using NSubstitute;

namespace _Display.Test
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
        public void ctor_IsConnected()
        {
            /*_uut.Show("test");
            _consoleWriter.Received(1).WriteToConsole("test");
            //Assert.That(_uut.Connected, Is.True);*/
        }

    }
}
