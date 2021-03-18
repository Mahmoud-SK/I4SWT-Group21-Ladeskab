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
		private StringBuilder sb_;

		public LogFile(StringBuilder sb)
		{
			sb_ = sb;
		}
		public void LogDoorLocked(int id)
		{
			sb_.AppendLine("Date: " + DateTime.Now + " - Døren er blevet lukket med ID: " + id);
			File.AppendAllText(Environment.CurrentDirectory + filename, sb_.ToString());
			sb_.Clear();
		}

		public void LogDoorUnlocked(int id)
		{
			sb_.AppendLine("Date: " + DateTime.Now + " - Døren er låst op med ID: " + id);
			File.AppendAllText(Environment.CurrentDirectory + filename, sb_.ToString());
			sb_.Clear();
		}
	}
}
