using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Ladeskab;
using Ladeskab.Interfaces;

namespace RfidRead.Test
{
	public class TestRfidReader
	{
		private RfidReader _uut;
		private RfidEventArgs _receivedEventArgs;

		[SetUp]
		public void Setup()
		{
			_uut = new RfidReader();
			_receivedEventArgs = null;

			_uut.RfidDetectedEvent +=
				(o, args) =>
				{
					_receivedEventArgs = args;
				};
		}

		[Test]
		public void RfidRead_EventFired()
		{
			_uut.OnRfidRead(10);
			Assert.That(_receivedEventArgs, Is.Not.Null);
		}

		[Test]
		public void CorrectRfidRead()
		{
			_uut.OnRfidRead(34);
			Assert.That(_receivedEventArgs.Id, Is.EqualTo(34));
		}
	}
}
