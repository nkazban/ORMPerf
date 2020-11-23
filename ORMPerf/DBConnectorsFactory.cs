using Dapper;
using ORMPerf.ADO;
using ORMPerf.Dapper;
using ORMPerf.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf
{
    public enum ConnectionType
    {
        EF,
        Dapper,
        ADO
    }
    public static class DBConnectorsFactory
    {
        static Dictionary<(DBType, ConnectionType), IDBConnector> _dictionary = new Dictionary<(DBType, ConnectionType), IDBConnector>();
        static DBConnectorsFactory()
        {
            //SqlMapper.AddTypeHandler(typeof(Guid), new GuidTypeHandler());

            _dictionary.Add((DBType.SQLite, ConnectionType.EF), new SQLiteEFConnector());
            _dictionary.Add((DBType.SQLite, ConnectionType.Dapper), new SQLiteDapperConnector());
            _dictionary.Add((DBType.SQLite, ConnectionType.ADO), new SQLiteADOConnector());

            _dictionary.Add((DBType.MSSQL, ConnectionType.EF), new MSSQLEFConnector());
            _dictionary.Add((DBType.MSSQL, ConnectionType.Dapper), new MSSQLDapperConnector());
            _dictionary.Add((DBType.MSSQL, ConnectionType.ADO), new MSSQLADOConnector());

            _dictionary.Add((DBType.MySql, ConnectionType.EF), new MySqlEFConnector());
            _dictionary.Add((DBType.MySql, ConnectionType.Dapper), new MySqlDapperConnector());
            _dictionary.Add((DBType.MySql, ConnectionType.ADO), new MySqlADOConnector());
        }

        public static IDBConnector GetConnector(DBType type, ConnectionType connection)
        {
            IDBConnector result = null;
            if (_dictionary.TryGetValue((type, connection), out result))
                return result;

            throw new NotImplementedException();
        }
    }
}
