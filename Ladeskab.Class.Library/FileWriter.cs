using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ladeskab
{
	public class FileWriter : IFileWriter
	{
		private string filename = "logfile.txt";
		public void WriteToFile(string s)
		{
			File.AppendAllText(Environment.CurrentDirectory + filename, s);
		}
	}
}
