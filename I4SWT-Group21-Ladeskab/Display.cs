using System;
using System.Collections.Generic;
using System.Text;

namespace I4SWT_Group21_Ladeskab
{
    public class Display : IDisplay
    {
        public void show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
