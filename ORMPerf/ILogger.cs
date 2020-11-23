using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf
{
    interface ILogger
    {
        void WriteLine(string line);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
