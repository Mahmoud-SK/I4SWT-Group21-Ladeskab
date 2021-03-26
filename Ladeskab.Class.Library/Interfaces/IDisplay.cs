using System;
using System.Collections.Generic;
using System.Text;

namespace Ladeskab.Interfaces
{
	public interface IDisplay
    {
        public void ShowInstruction(string instruction);
        public void ShowStatus(string status);
    }
}
