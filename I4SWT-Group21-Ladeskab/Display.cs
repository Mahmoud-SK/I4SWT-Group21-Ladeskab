using System;
using System.Collections.Generic;
using System.Text;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class Display : IDisplay
    {
        public void show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
