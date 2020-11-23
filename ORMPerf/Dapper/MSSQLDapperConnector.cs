using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ORMPerf.Dapper
{
    class MSSQLDapperConnector : IDBConnector
    {
        Database _db;

        public MSSQLDapperConnector()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MSSQL);
        }

        public string Name => "MS SQL Dapper";

        public void AddRandomRows(int count)
        {
            var list = new SimpleModel[count];
            for(int i = 0; i < count; i++)
            {
                list[i] = SimpleModel.CreateRandom();
            }

            using(var conn = new SqlConnection(_db.ConnectionString))
            {
                conn.Insert(list);
            }
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using(var conn = new SqlConnection(_db.ConnectionString))
            {
                for (int i = 0; i < count; i++)
                {
                    conn.Insert(SimpleModel.CreateRandom());
                }
            }
        }

        public void DeleteAllRows()
        {
            using(var conn = new SqlConnection(_db.ConnectionString))
            {
                conn.Execute("DELETE FROM SimpleModels");
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using (var conn = new SqlConnection(_db.ConnectionString))
            {
                return conn.Query<SimpleModel>("SELECT * FROM SimpleModels");
            }
        }
    }
}
