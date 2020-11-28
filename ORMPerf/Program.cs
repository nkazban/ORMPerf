using System;
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
            File.AppendAllText(_path, line + "\n");
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
            string logFileName = $"D:\\ORMPerfLog_{DateTime.Now:d_MM_yyyy_h_m_s}.txt";
            var logger = new GeneralLogger(logFileName);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var bench = new Benchmark(DBConnectorsFactory.GetConnector((DBType)i, (ConnectionType)j), logger);
                    bench.Init();
                    for (int k = 0; k < 10; k++)
                    {
                        logger.WriteLine($"<--- Test pack #{k + 1} --->");
                        bench.WritingTest(100);
                        bench.WritingOneByOneTest(100);
                        bench.ReadingTest();
                        bench.DeletingTest();
                    }
                    bench.Dispose();
                }
            }
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}