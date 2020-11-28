using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ORMPerf
{
    using Core;
    using System.Linq;

    class Benchmark : IDisposable
    {
        IDBConnector _connector;
        Stopwatch _sw;
        ILogger _logger;

        IDataAggregator _dataAggregator;

        public Benchmark(IDBConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
            _sw = new Stopwatch();
            _dataAggregator = new SimpleDataAggregator();
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
            _dataAggregator.AddInfo(TestType.Reading, _sw.Elapsed);
            _logger.WriteLine($"Elapsed time {_sw.Elapsed}");
        }

        public void WritingTest(int rowsCount)
        {
            _logger.WriteLine("Started writing test.");
            _sw.Restart();
            try
            {
                _connector.AddRandomRows(rowsCount);
                _sw.Stop();
                _dataAggregator.AddInfo(TestType.Writing, _sw.Elapsed);
                _logger.WriteLine($"Elapsed time {_sw.Elapsed}");
            }
            catch (Exception e)
            {
                _logger.WriteLine("Catched error : " + e.ToString());
            }
        }

        public void WritingOneByOneTest(int rowsCount)
        {
            _logger.WriteLine("Started writing one by one test.");
            _sw.Restart();
            _connector.AddRandomRowsOneByOne(rowsCount);
            _sw.Stop();
            _dataAggregator.AddInfo(TestType.WritingOneByOne, _sw.Elapsed);
            _logger.WriteLine($"Elapsed time {_sw.Elapsed}");
        }

        public void DeletingTest()
        {
            _logger.WriteLine("Started deleting test.");
            _sw.Restart();
            _connector.DeleteAllRows();
            _sw.Stop();
            _dataAggregator.AddInfo(TestType.Deleting, _sw.Elapsed);
            _logger.WriteLine($"Elapsed time {_sw.Elapsed}");
        }

        public void Dispose()
        {
            _logger.WriteLine(string.Format("{0, 20}|{1, 20}|{2, 20}|{3, 20}", "Writing", "Writing one by one", "Reading", "Deleting"));
            _logger.WriteLine(string.Format("{0, 20}|{1, 20}|{2, 20}|{3, 20}", 
                _dataAggregator.GetAverage(TestType.Writing),
                _dataAggregator.GetAverage(TestType.WritingOneByOne),
                _dataAggregator.GetAverage(TestType.Reading),
                _dataAggregator.GetAverage(TestType.Deleting)));
        }

        void AddHeader()
        {
            _logger.WriteLine($"<===| {_connector.Name} |===>");
        }
    }
}
