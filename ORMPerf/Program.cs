using System;
using ORMPerf.EF;
using ORMPerf.Dapper;
using Dapper;

namespace ORMPerf
{
    class Program
    {
        static void Main(string[] args)
        {
            IDBConnector connector = DBConnectorsFactory.GetConnector(DBType.MSSQL, ConnectionType.ADO);
            connector.Connect();
            //connector.AddRandomRows(100);
            var data = connector.ReadAll();
            foreach(var d in data)
            {
                Console.WriteLine(d.ToString());
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}