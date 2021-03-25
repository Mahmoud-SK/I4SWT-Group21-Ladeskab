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

        public Display(IConsoleWriter consoleWriter)
        {
            _writer = consoleWriter;
        }

        public void Show(string message)
        {
            _writer.WriteToConsole(message);
        }
    }
}
