using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
	public interface ILogFile
	{
		public void LogDoorUnlocked(int id);
		public void LogDoorLocked(int id);
	}
}
