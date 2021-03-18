using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ladeskab.Interfaces;
namespace Ladeskab
{
	public class LogFile : ILogFile
	{
		private string filename = "logfile.txt";

		public LogFile()
		{
			
		}
		public void LogDoorLocked(int id)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Date: " + DateTime.Now + " - Døren er blevet lukket med ID: " + id);
			File.AppendAllText(Environment.CurrentDirectory + filename, sb.ToString());
		}

		public void LogDoorUnlocked(int id)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Date: " + DateTime.Now + " - Døren er låst op med ID: " + id);
			File.AppendAllText(Environment.CurrentDirectory + filename, sb.ToString());
		}
	}
}
