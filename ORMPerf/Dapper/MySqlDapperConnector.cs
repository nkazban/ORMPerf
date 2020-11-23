using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORMPerf.Dapper
{
    class MySqlDapperConnector : IDBConnector
    {
        Database _db;

        public MySqlDapperConnector()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.MySql);
        }

        public string Name => "MySql Dapper";

        public void AddRandomRows(int count)
        {
            var list = new SimpleModel[count];
            for (int i = 0; i < count; i++)
            {
                list[i] = SimpleModel.CreateRandom();
            }

            using (var conn = new MySqlConnection(_db.ConnectionString))
            {
                conn.Insert(list);
            }
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using (var conn = new MySqlConnection(_db.ConnectionString))
            {
                for (int i = 0; i < count; i++)
                {
                    conn.Insert(SimpleModel.CreateRandom());
                }
            }
        }

        public void DeleteAllRows()
        {
            using (var conn = new MySqlConnection(_db.ConnectionString))
            {
                conn.Execute("DELETE FROM SimpleModels");
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using(var conn = new MySqlConnection(_db.ConnectionString))
            {
                return conn.Query<SimpleModel>("SELECT * FROM SimpleModels");
            }
        }
    }
}
