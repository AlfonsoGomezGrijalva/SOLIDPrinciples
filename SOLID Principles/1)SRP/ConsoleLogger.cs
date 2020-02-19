using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Principles.SRP
{
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
