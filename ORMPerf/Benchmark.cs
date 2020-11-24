using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ORMPerf
{
    using Core;
    class Benchmark
    {
        IDBConnector _connector;
        Stopwatch _sw;
        ILogger _logger;

        public Benchmark(IDBConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
            _sw = new Stopwatch();
        }

        public void Init()
        {
            AddHeader();
        }

        public void ReadingTest()
        {
            _logger.WriteLine("Started reading test.");
            _sw.Restart();
            _connector.ReadAll();
            _sw.Stop();
            PrintResult();
        }

        public void WritingTest(int rowsCount)
        {
            _logger.WriteLine("Started writing test.");
            _sw.Restart();
            try
            {
                _connector.AddRandomRows(rowsCount);
                _sw.Stop();
                PrintResult();
            }
            catch { }
        }

        public void WritingOneByOneTest(int rowsCount)
        {
            _logger.WriteLine("Started writing one by one test.");
            _sw.Restart();
            _connector.AddRandomRowsOneByOne(rowsCount);
            _sw.Stop();
            PrintResult();
        }

        public void DeletingTest()
        {
            _logger.WriteLine("Started deleting test.");
            _sw.Restart();
            _connector.DeleteAllRows();
            _sw.Stop();
            PrintResult();
        }

        void AddHeader()
        {
            _logger.WriteLine($"<===| {_connector.Name} |===>");
        }

        void PrintResult()
        {
            _logger.WriteLine($"Elapsed time {_sw.Elapsed}");
        }
    }
}
