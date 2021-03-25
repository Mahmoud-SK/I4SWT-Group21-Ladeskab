using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab;

namespace _Display.Test
{
    [TestFixture]
    public class TestDisplay
    {
        private Display _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        /*[Test]
        public void ctor_IsConnected()
        {
            _uut.Show("test");
            Assert.That(_uut.Connected, Is.True);
        }*/

    }
}
