using System;
using ORMPerf.EF;
using ORMPerf.Dapper;
using Dapper;
using System.Threading;

namespace ORMPerf
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            for (int i = 2; i > -1; i--)
            {
                for (int j = 0; j < 3; j++)
                {
                    IDBConnector connector = DBConnectorsFactory.GetConnector((DBType)i, (ConnectionType)(j % 3));

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