using System;
using System.Threading;
using System.IO;

namespace ORMPerf
{
    using Core;

    class ConsoleLogger : ILogger
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }

    class FileLogger : ILogger
    {
        string _path;

        public FileLogger(string path)
        {
            _path = path;
            File.CreateText(path).Dispose();
        }

        public void WriteLine(string line)
        {
            File.WriteAllText(_path, line);
        }
    }
    /// <summary>
    /// File and console logger
    /// </summary>
    class GeneralLogger : ILogger
    {
        FileLogger _fileLogger;
        ConsoleLogger _consoleLogger;

        public GeneralLogger(string path)
        {
            _consoleLogger = new ConsoleLogger();
            _fileLogger = new FileLogger(path);
        }

        public void WriteLine(string line)
        {
            _consoleLogger.WriteLine(line);
            _fileLogger.WriteLine(line);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            for (int i = 2; i > -1; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    IDBConnector connector = DBConnectorsFactory.GetConnector((DBType)i, (ConnectionType)j);

                    var bench = new Benchmark(connector, logger);
                    bench.Init();
                    bench.WritingTest(100);
                    bench.WritingOneByOneTest(100);
                    bench.ReadingTest();
                    bench.DeletingTest();
                    Thread.Sleep(100);
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}