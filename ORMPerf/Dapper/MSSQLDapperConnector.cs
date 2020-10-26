using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ORMPerf.Dapper
{
    class MSSQLDapperConnector : IDBConnector
    {
        Database _db;
        public void AddRandomRows(int count)
        {
        }

        public void Connect()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MSSQL);
        }

        public void DeleteAllRows()
        {

        }

        public void Disconnect()
        {

        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using (var conn = new SqlConnection(_db.ConnectionString))
            {
                return conn.Query<SimpleModel>("SELECT * FROM Models");
            }
        }
    }
}
