using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Ladeskab.Interfaces;
namespace Ladeskab
{
	public class LogFile : ILogFile
	{
		private IFileWriter _writer;
		private ITimeProvider _time;

		public LogFile(IFileWriter writer, ITimeProvider time)
		{
			_writer = writer;
			_time = time;
		}
		public void LogDoorLocked(int id)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Date: " + _time.ProvideDate() + " - Døren er blevet lukket med ID: " + id);
			_writer.WriteToFile(sb.ToString());
		}

		public void LogDoorUnlocked(int id)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Date: " + _time.ProvideDate() + " - Døren er låst op med ID: " + id);
			_writer.WriteToFile(sb.ToString());
		}
	}
}
