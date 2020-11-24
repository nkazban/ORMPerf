using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace ORMPerf.Core.Dapper
{
    class SQLiteDapperConnector : IDBConnector
    {
        Database _db;

        public SQLiteDapperConnector()
        {
            _db = DBConfigMapper.GetDBConfig(DBType.SQLite);
        }

        public string Name => "SQLite Dapper";

        public void AddRandomRows(int count)
        {
            var list = new SimpleModel[count];
            for (int i = 0; i < count; i++)
            {
                list[i] = SimpleModel.CreateRandom();
            }

            using (var conn = new SqliteConnection(_db.ConnectionString))
            {
                conn.Insert(list);
            }
        }

        public void AddRandomRowsOneByOne(int count)
        {
            using (var conn = new SqliteConnection(_db.ConnectionString))
            {
                for (int i = 0; i < count; i++)
                {
                    conn.Insert(SimpleModel.CreateRandom());
                }
            }
        }

        public void DeleteAllRows()
        {
            using (var conn = new SqliteConnection(_db.ConnectionString))
            {
                conn.Execute("DELETE FROM SimpleModels");
            }
        }

        public IEnumerable<SimpleModel> ReadAll()
        {
            using(var connection = new SqliteConnection(_db.ConnectionString))
            {
                return connection.Query<SimpleModel>("SELECT * FROM SimpleModels");
            }
        }
    }
}
