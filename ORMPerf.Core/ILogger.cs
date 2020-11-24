using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ORMPerf.Core
{
    public interface ILogger
    {
        void WriteLine(string line);
    }
}
