using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ORMPerf.ADO
{
    class MSSQLADOConnector : IDBConnector
    {
        Database _db;
        public void AddRandomRows(int count)
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MSSQL);
        }

        public void DeleteAllRows()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            var result = new List<SimpleModel>();
            using (var conn = new SqlConnection(_db.ConnectionString))
            {
                conn.Open();

                var command = conn.CreateCommand();
                command.CommandText = @"SELECT * FROM Models";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ReadModel());
                    }
                }
            }
            return result;
        }
    }
}
