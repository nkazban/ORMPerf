using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace ORMPerf.Dapper
{
    class SQLiteDapperConnector : IDBConnector
    {
        Database _db;
        public void AddRandomRows(int count)
        {
        }

        public void Connect()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.SQLite);
        }

        public void DeleteAllRows()
        {
        }

        public void Disconnect()
        {
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using(var connection = new SqliteConnection(_db.ConnectionString))
            {
                return connection.Query<SimpleModel>("SELECT * FROM Models");
            }
        }
    }
}
