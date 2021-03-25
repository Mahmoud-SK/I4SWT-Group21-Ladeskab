using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Class.Library.Interfaces
{
	public class ConsoleWriter : IConsoleWriter
	{
		public void WriteToConsole(string s)
		{
			Console.WriteLine(s);
		}
	}
}
