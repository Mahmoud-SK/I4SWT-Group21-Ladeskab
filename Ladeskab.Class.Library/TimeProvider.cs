using Ladeskab.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab
{
	public class TimeProvider : ITimeProvider
	{
		public DateTime ProvideDate()
		{
			return DateTime.Now;
		}
	}
}
