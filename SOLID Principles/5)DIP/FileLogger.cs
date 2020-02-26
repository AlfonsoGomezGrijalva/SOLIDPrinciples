using SOLID_Principles.ISP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLID_Principles.DIP
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
