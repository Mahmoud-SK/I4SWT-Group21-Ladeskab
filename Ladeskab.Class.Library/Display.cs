using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Class.Library.Interfaces;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        private IConsoleWriter _writer;
        private string _instruction;
        private string _status;

        public Display(IConsoleWriter consoleWriter)
        {
            _writer = consoleWriter;
            _instruction = "";
            _status = "";
        }

        public void ShowInstruction(string instruction)
        {
            _instruction = instruction;
            Print();
        }

        public void ShowStatus(string status)
        {
            _status = status;
            Print();
        }

        private void Print()
        {
            _writer.WriteToConsole("-----------------------------------");
            _writer.WriteToConsole(_instruction);
            _writer.WriteToConsole(_status);
            _writer.WriteToConsole("-----------------------------------");
        }
    }
}
