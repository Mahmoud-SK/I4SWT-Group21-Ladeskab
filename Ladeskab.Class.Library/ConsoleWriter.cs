using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
	public class ConsoleWriter : IConsoleWriter
	{
		public void WriteToConsole(string s)
		{
			Console.WriteLine(s);
		}
	}
}
