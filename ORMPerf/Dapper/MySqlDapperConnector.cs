using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Dapper
{
    class MySqlDapperConnector : IDBConnector
    {
        Database _db;

        public void AddRandomRows(int count)
        {
        }

        public void Connect()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MySql);
        }

        public void DeleteAllRows()
        {
        }

        public void Disconnect()
        {
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using(var conn = new MySqlConnection(_db.ConnectionString))
            {
                return conn.Query<SimpleModel>("SELECT * FROM Models");
            }
        }
    }
}
